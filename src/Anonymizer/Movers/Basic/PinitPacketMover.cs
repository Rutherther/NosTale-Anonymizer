//
//  PinitPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Groups;
using NosSmooth.PacketSerializer.Abstractions.Common;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class PinitPacketMover : AbstractMover<PinitPacket>
{
    /// <inheritdoc />
    public override PinitPacket Move(IAnonymizer anonymizer, PinitPacket packet)
    {
        return packet with
        {
            PinitSubPackets = packet.PinitSubPackets.Select
            (
                x => x with
                {
                    EntityId = anonymizer.AnonymizeId(x.EntityId),
                    MateSubPacket = x.MateSubPacket is null
                        ? null
                        : x.MateSubPacket with
                        {
                            Name = x.MateSubPacket.Name is null
                                ? null
                                : (NameString)anonymizer.AnonymizeName(x.MateSubPacket.Name)
                        },
                    PlayerSubPacket = x.PlayerSubPacket is null
                        ? null
                        : x.PlayerSubPacket with
                        {
                            GroupId = x.PlayerSubPacket.GroupId is null
                                ? null
                                : anonymizer.AnonymizeId(x.PlayerSubPacket.GroupId.Value),
                            Name = x.PlayerSubPacket.Name is null
                                ? null
                                : (NameString)anonymizer.AnonymizeName(x.PlayerSubPacket.Name)
                        }
                }
            ).ToArray()
        };
    }
}