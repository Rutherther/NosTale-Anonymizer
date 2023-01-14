//
//  PstPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Groups;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class PstPacketMover : AbstractMover<PstPacket>
{
    /// <inheritdoc />
    public override PstPacket Move(IAnonymizer anonymizer, PstPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}