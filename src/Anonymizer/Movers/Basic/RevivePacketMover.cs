//
//  RevivePacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Entities;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class RevivePacketMover : AbstractMover<RevivePacket>
{
    /// <inheritdoc />
    public override RevivePacket Move(IAnonymizer anonymizer, RevivePacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}