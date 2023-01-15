//
//  UPetPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Client.Battle;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class UPetPacketMover : AbstractMover<UsePetSkillPacket>
{
    /// <inheritdoc />
    public override UsePetSkillPacket Move(IAnonymizer anonymizer, UsePetSkillPacket packet)
        => packet with
        {
            MateTransportId = anonymizer.AnonymizeId(packet.MateTransportId),
            TargetId = anonymizer.AnonymizeId(packet.TargetId)
        };
}