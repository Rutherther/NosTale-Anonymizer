//
//  RaidPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Raids;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class RaidPacketMover : AbstractMover<RaidPacket>
{
    /// <inheritdoc />
    public override RaidPacket Move(IAnonymizer anonymizer, RaidPacket packet)
        => packet with
        {
            LeaderId = packet.LeaderId is null ? null : anonymizer.AnonymizeId(packet.LeaderId.Value),
            ListMembersPlayerIds = packet.ListMembersPlayerIds?.Select(anonymizer.AnonymizeId).ToArray(),
            PlayerHealths = packet.PlayerHealths?.Select
            (
                x => x with
                {
                    PlayerId = anonymizer.AnonymizeId(x.PlayerId)
                }
            ).ToArray()
        };
}