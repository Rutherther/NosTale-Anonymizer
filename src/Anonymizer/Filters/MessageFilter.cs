//
//  MessageFilter.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.PacketSerializer.Abstractions.Attributes;

namespace Anonymizer.Filters;

/// <summary>
/// Filters out sent messages.
/// </summary>
public class MessageFilter : IFilter
{
    /// <inheritdoc />
    public bool Filter(PacketInfo packetInfo)
    {
        if (packetInfo.Source == PacketSource.Client)
        {
            return !(packetInfo.Packet.StartsWith('/') || packetInfo.Packet.StartsWith
                (';') || packetInfo.Packet.StartsWith(":"));
        }

        return true;
    }
}