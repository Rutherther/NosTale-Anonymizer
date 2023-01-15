//
//  IPacketDestination.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Skills;

namespace Anonymizer.Sinks;

/// <summary>
/// An interface for sending packets to an arbitrary destination.
/// </summary>
public interface IPacketDestination
{
    /// <summary>
    /// Write the given packet string into the destination.
    /// </summary>
    /// <param name="packetInfo">The packet info to write.</param>
    /// <param name="ct">The cancellation token used for cancelling the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task WritePacketAsync(PacketInfo packetInfo, CancellationToken ct = default);
}