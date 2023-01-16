//
//  CInfoPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Character;
using NosSmooth.PacketSerializer.Abstractions;
using NosSmooth.PacketSerializer.Abstractions.Common;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class CInfoPacketMover : AbstractMover<CInfoPacket>
{
    /// <inheritdoc />
    public override CInfoPacket Move(IAnonymizer anonymizer, CInfoPacket packet)
        => packet with
        {
            CharacterId = anonymizer.AnonymizeId(packet.CharacterId),
            Name = anonymizer.AnonymizeName(packet.Name),
            FamilySubPacket = packet.FamilySubPacket.Value is null ? null : packet.FamilySubPacket with
            {
                Value = packet.FamilySubPacket.Value with
                {
                    FamilyId = anonymizer.AnonymizeId(packet.FamilySubPacket.Value.FamilyId)
                }
            },
            FamilyName = anonymizer.AnonymizeName(packet.FamilyName),
            GroupId = packet.GroupId is null ? null : anonymizer.AnonymizeId(packet.GroupId.Value)
        };
}