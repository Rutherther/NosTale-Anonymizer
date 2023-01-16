//
//  InPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Maps;
using NosSmooth.PacketSerializer.Abstractions.Common;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class InPacketMover : AbstractMover<InPacket>
{
    /// <inheritdoc />
    public override InPacket Move(IAnonymizer anonymizer, InPacket packet)
    {
        return packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId),
            Name = packet.Name is null ? null : (NameString)anonymizer.AnonymizeName(packet.Name),
            PlayerSubPacket = packet.PlayerSubPacket is null
                ? null
                : packet.PlayerSubPacket with
                {
                    GroupId = packet.PlayerSubPacket.GroupId is null
                        ? null
                        : anonymizer.AnonymizeId(packet.PlayerSubPacket.GroupId.Value),
                    FamilyName = packet.PlayerSubPacket.FamilyName is null
                        ? null
                        : anonymizer.AnonymizeName(packet.PlayerSubPacket.FamilyName),
                    FamilySubPacket = packet.PlayerSubPacket.FamilySubPacket with
                    {
                        Value = packet.PlayerSubPacket.FamilySubPacket.Value is null
                            ? null
                            : packet.PlayerSubPacket.FamilySubPacket.Value with
                            {
                                FamilyId = anonymizer.AnonymizeId
                                    (packet.PlayerSubPacket.FamilySubPacket.Value.FamilyId)
                            }
                    }
                },
            NonPlayerSubPacket = packet.NonPlayerSubPacket is null
                ? null
                : packet.NonPlayerSubPacket with
                {
                    OwnerId = packet.NonPlayerSubPacket.OwnerId is null
                        ? null
                        : anonymizer.AnonymizeId(packet.NonPlayerSubPacket.OwnerId.Value),
                    Name = packet.NonPlayerSubPacket.Name is null
                        ? null
                        : (NameString)anonymizer.AnonymizeName(packet.NonPlayerSubPacket.Name)
                },
            ItemSubPacket = packet.ItemSubPacket is null
                ? null
                : packet.ItemSubPacket with
                {
                    OwnerId = anonymizer.AnonymizeId(packet.ItemSubPacket.OwnerId)
                }
        };
    }
}