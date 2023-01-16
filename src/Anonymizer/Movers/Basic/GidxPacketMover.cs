//
//  GidxPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Families;
using NosSmooth.PacketSerializer.Abstractions.Common;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class GidxPacketMover : AbstractMover<GidxPacket>
{
    /// <inheritdoc />
    public override GidxPacket Move(IAnonymizer anonymizer, GidxPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId),
            FamilyName = packet.FamilyName is null ? null : (NameString)anonymizer.AnonymizeName(packet.FamilyName.Name),
            FamilySubPacket = packet.FamilySubPacket with
            {
                Value = packet.FamilySubPacket.Value is null ? null : packet.FamilySubPacket.Value with
                {
                    FamilyId = anonymizer.AnonymizeId(packet.FamilySubPacket.Value.FamilyId)
                }
            }
        };
}