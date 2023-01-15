//
//  EqPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Inventory;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class EqPacketMover : AbstractMover<EqPacket>
{
    /// <inheritdoc />
    public override EqPacket Move(IAnonymizer anonymizer, EqPacket packet)
        => packet with
        {
            CharacterId = anonymizer.AnonymizeId(packet.CharacterId)
        };
}