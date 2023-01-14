//
//  RbossPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Raids;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class RbossPacketMover : AbstractMover<RbossPacket>
{
    /// <inheritdoc />
    public override RbossPacket Move(IAnonymizer anonymizer, RbossPacket packet)
        => packet with
        {
            EntityId = packet.EntityId is null ? null : anonymizer.AnonymizeId(packet.EntityId.Value)
        };
}