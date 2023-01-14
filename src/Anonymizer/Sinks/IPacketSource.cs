//
//  IPacketSource.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;

namespace Anonymizer.Sinks;

/// <summary>
/// An interface for receiving packets from an arbitrary source.
/// </summary>
public interface IPacketSource
{
    /// <summary>
    /// The current cursor position (current packet index).
    /// </summary>
    public long Cursor { get; }

    /// <summary>
    /// Tries to get next packet, if there is any.
    /// </summary>
    /// <remarks>
    /// Moves the cursor.
    /// </remarks>
    /// <param name="packetInfo">The information about next packet.</param>
    /// <param name="ct">The cancellation token used for cancelling the operation.</param>
    /// <returns>Whether next packet was loaded and cursor moved. If false, there are no more packets.</returns>
    public Task<bool> TryGetNextPacketAsync([NotNullWhen(true)] out PacketInfo? packetInfo, CancellationToken ct = default);
}