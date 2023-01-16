//
//  ThrowPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Maps;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class ThrowPacketMover : AbstractMover<ThrowPacket>
{
    /// <inheritdoc />
    public override ThrowPacket Move(IAnonymizer anonymizer, ThrowPacket packet)
        => packet with
        {
            DropId = anonymizer.AnonymizeId(packet.DropId)
        };
}