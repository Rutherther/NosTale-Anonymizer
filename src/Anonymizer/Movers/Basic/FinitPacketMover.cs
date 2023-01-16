//
//  FinitPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Relations;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class FinitPacketMover : AbstractMover<FInitPacket>
{
    /// <inheritdoc />
    public override FInitPacket Move(IAnonymizer anonymizer, FInitPacket packet)
        => packet with
        {
            FriendSubPackets = packet.FriendSubPackets.Select
            (
                x => x with
                {
                    Name = anonymizer.AnonymizeName(x.Name),
                    PlayerId = anonymizer.AnonymizeId(x.PlayerId)
                }
            ).ToArray()
        };
}