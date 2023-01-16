//
//  DmPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Battle;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class DmPacketMover : AbstractMover<DmPacket>
{
    /// <inheritdoc />
    public override DmPacket Move(IAnonymizer anonymizer, DmPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}