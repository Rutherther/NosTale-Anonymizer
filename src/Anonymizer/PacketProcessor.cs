//
//  PacketProcessor.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using Anonymizer.Filters;
using Anonymizer.Movers;
using Anonymizer.Sinks;
using Microsoft.Extensions.Options;
using NosSmooth.Packets;
using NosSmooth.PacketSerializer;
using NosSmooth.PacketSerializer.Abstractions.Attributes;
using Remora.Results;

namespace Anonymizer;

/// <summary>
/// Processes packets, anonymizes or filters them.
/// </summary>
public class PacketProcessor
{
    private readonly IPacketSerializer _packetSerializer;
    private readonly IAnonymizer _anonymizer;
    private readonly RegisteredMovers _registeredMovers;
    private readonly IReadOnlyList<IFilter> _filters;
    private readonly IReadOnlyList<IMover> _movers;

    /// <summary>
    /// Initializes a new instance of the <see cref="PacketProcessor"/> class.
    /// </summary>
    /// <param name="packetSerializer">The packet serializer.</param>
    /// <param name="anonymizer">The anonymizer.</param>
    /// <param name="filters">The filters.</param>
    /// <param name="movers">The movers.</param>
    /// <param name="registeredMovers">The registered movers.</param>
    public PacketProcessor
    (
        IPacketSerializer packetSerializer,
        IAnonymizer anonymizer,
        IEnumerable<IFilter> filters,
        IEnumerable<IMover> movers,
        IOptions<RegisteredMovers> registeredMovers
    )
    {
        _packetSerializer = packetSerializer;
        _anonymizer = anonymizer;
        _registeredMovers = registeredMovers.Value;
        _filters = filters.ToList();
        _movers = movers.ToList();
    }

    /// <summary>
    /// Process one packet, anonymize it.
    /// </summary>
    /// <param name="packetInfo">The packet to anonymize.</param>
    /// <returns>The processed packet.</returns>
    public Result<ProcessedPacket> ProcessPacket(PacketInfo packetInfo)
    {
        foreach (var filter in _filters)
        {
            if (!filter.Filter(packetInfo))
            {
                return new ProcessedPacket(packetInfo.Packet, packetInfo.Packet, false);
            }
        }

        var header = packetInfo.Packet.Split(' ')[0];
        if (!_registeredMovers.ShouldMove(header))
        {
            return new ProcessedPacket(packetInfo.Packet, packetInfo.Packet, true);
        }

        var packetResult = _packetSerializer.Deserialize(packetInfo.Packet, packetInfo.Source);
        if (!packetResult.IsDefined(out var packet))
        {
            return Result<ProcessedPacket>.FromError(packetResult);
        }

        foreach (var mover in _movers)
        {
            if (mover.ShouldHandle(packet))
            {
                var movedPacket = mover.Move(_anonymizer, packet);
                var serializedResult = _packetSerializer.Serialize(movedPacket);
                if (!serializedResult.IsDefined(out var serialized))
                {
                    return Result<ProcessedPacket>.FromError(serializedResult);
                }

                return new ProcessedPacket(packetInfo.Packet, serialized, true);
            }
        }

        return new ProcessedPacket(packetInfo.Packet, packetInfo.Packet, true);
    }

    /// <summary>
    /// Process the whole source and put the processed packets into the given destination.
    /// </summary>
    /// <param name="source">The source to get packets from.</param>
    /// <param name="destination">The destination to put processed packets into.</param>
    /// <param name="ct">The cancellation token for cancelling the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<Result> ProcessSourceDestination
        (IPacketSource source, IPacketDestination destination, CancellationToken ct = default)
    {
        var errors = new List<IResult>();
        PacketInfo? packetInfo;
        while ((packetInfo = await source.TryGetNextPacketAsync(ct)) != null)
        {
            var processedPacketResult = ProcessPacket(packetInfo);
            if (!processedPacketResult.IsDefined(out var processedPacket))
            {
                errors.Add(Result.FromError(processedPacketResult));
                continue;
            }

            if (processedPacket.Keep)
            {
                await destination.WritePacketAsync
                (
                    packetInfo with
                    {
                        Packet = processedPacket.NewPacketString
                    },
                    ct
                );
            }
        }

        return errors.Count switch
        {
            0 => Result.FromSuccess(),
            1 => (Result)errors[0],
            _ => new AggregateError(errors)
        };
    }
}