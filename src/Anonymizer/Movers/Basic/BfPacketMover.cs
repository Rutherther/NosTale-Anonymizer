//
//  BfPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Buffs;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class BfPacketMover : AbstractMover<BfPacket>
{
    /// <inheritdoc />
    public override BfPacket Move(IAnonymizer anonymizer, BfPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}