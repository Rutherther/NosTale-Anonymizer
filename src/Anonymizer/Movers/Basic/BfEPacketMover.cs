//
//  BfEPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Buffs;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class BfEPacketMover : AbstractMover<BfEPacket>
{
    /// <inheritdoc />
    public override BfEPacket Move(IAnonymizer anonymizer, BfEPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}