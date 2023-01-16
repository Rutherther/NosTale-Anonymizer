//
//  DiePacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Entities;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class DiePacketMover : AbstractMover<DiePacket>
{
    /// <inheritdoc />
    public override DiePacket Move(IAnonymizer anonymizer, DiePacket packet)
    {
        return packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId),
            TargetEntityId = anonymizer.AnonymizeId(packet.TargetEntityId)
        };
    }
}