//
//  IPacketDestination.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Anonymizer.Sinks;

/// <summary>
/// An interface for sending packets to an arbitrary destination.
/// </summary>
public interface IPacketDestination
{
    /// <summary>
    /// Write the given packet string into the destination.
    /// </summary>
    /// <param name="packetString">The packet string to write.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task WritePacketAsync(string packetString);
}