//
//  PairyPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Inventory;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class PairyPacketMover : AbstractMover<PairyPacket>
{
    /// <inheritdoc />
    public override PairyPacket Move(IAnonymizer anonymizer, PairyPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}