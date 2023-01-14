//
//  OutPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Maps;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class OutPacketMover : AbstractMover<OutPacket>
{
    /// <inheritdoc />
    public override OutPacket Move(IAnonymizer anonymizer, OutPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}