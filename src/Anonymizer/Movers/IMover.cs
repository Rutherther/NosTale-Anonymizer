//
//  IMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets;

namespace Anonymizer.Movers;

/// <summary>
/// Moves a packet, anonymizes it.
/// </summary>
public interface IMover
{
    /// <summary>
    /// Check whether to handle given packet.
    /// </summary>
    /// <param name="packet">The packet to check.</param>
    /// <returns>Whether to handle that packet.</returns>
    public bool ShouldHandle(IPacket packet);

    /// <summary>
    /// Move the packet, anonymize it.
    /// </summary>
    /// <param name="anonymizer">The anonymizer to use.</param>
    /// <param name="packet">The packet.</param>
    /// <returns>Moved packet.</returns>
    public IPacket Move(IAnonymizer anonymizer, IPacket packet);
}

/// <summary>
/// Moves a packet, anonymizes it.
/// </summary>
/// <typeparam name="TPacket">The type of the packet.</typeparam>
public interface IMover<TPacket> : IMover
    where TPacket : IPacket
{
    /// <summary>
    /// Move the packet, anonymize it.
    /// </summary>
    /// <param name="anonymizer">The anonymizer.</param>
    /// <param name="packet">The packet to anonymize.</param>
    /// <returns>The new packet.</returns>
    public TPacket Move(IAnonymizer anonymizer, TPacket packet);
}