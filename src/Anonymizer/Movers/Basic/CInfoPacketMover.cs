//
//  CInfoPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Character;

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
            FamilyId = packet.FamilyId is null ? null : anonymizer.AnonymizeName(packet.FamilyId),
            FamilyName = packet.FamilyName is null ? null : anonymizer.AnonymizeName(packet.FamilyName),
            GroupId = packet.GroupId is null ? null : anonymizer.AnonymizeId(packet.GroupId.Value)
        };
}