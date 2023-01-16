//
//  FinfoPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Relations;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class FinfoPacketMover : AbstractMover<FInfoPacket>
{
    /// <inheritdoc />
    public override FInfoPacket Move(IAnonymizer anonymizer, FInfoPacket packet)
        => packet with
        {
            FriendSubPackets = packet.FriendSubPackets.Select
            (
                x => x with
                {
                    PlayerId = anonymizer.AnonymizeId(x.PlayerId),
                    Name = anonymizer.AnonymizeName(x.Name)
                }
            ).ToArray()
        };
}