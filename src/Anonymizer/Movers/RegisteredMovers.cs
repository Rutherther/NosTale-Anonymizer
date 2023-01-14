//
//  RegisteredMovers.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Reflection;
using Microsoft.Extensions.Options;
using NosSmooth.Packets;
using NosSmooth.PacketSerializer.Abstractions.Attributes;

namespace Anonymizer.Movers;

/// <summary>
/// A class containing all of the registered movers,
/// initialized as <see cref="IOptions{TOptions}"/>
/// by the service extension methods. Used inside of
/// <see cref="PacketProcessor"/>.
/// </summary>
public class RegisteredMovers
{
    private readonly HashSet<string> _packetHeaders;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisteredMovers"/> class.
    /// </summary>
    public RegisteredMovers()
    {
        _packetHeaders = new HashSet<string>();
    }

    /// <summary>
    /// Add the given mover packet type.
    /// </summary>
    /// <typeparam name="TPacket">The packet to add.</typeparam>
    public void AddMover<TPacket>()
        where TPacket : IPacket
    {
        var header = typeof(TPacket).GetCustomAttribute<PacketHeaderAttribute>();

        if (header?.Identifier is not null)
        {
            _packetHeaders.Add(header.Identifier);
        }
    }

    /// <summary>
    /// Checks whether the given packet header has a mover registered.
    /// </summary>
    /// <param name="packetHeader">The packet header.</param>
    /// <returns>Whether to try to move the packet.</returns>
    public bool ShouldMove(string packetHeader)
    {
        return _packetHeaders.Contains(packetHeader);
    }
}