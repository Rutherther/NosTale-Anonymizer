//
//  RcPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Battle;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class RcPacketMover : AbstractMover<RcPacket>
{
    /// <inheritdoc />
    public override RcPacket Move(IAnonymizer anonymizer, RcPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}