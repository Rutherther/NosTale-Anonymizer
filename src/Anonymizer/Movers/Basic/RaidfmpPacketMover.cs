//
//  RaidfmpPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Raids;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class RaidfmpPacketMover : AbstractMover<RaidfmpPacket>
{
    /// <inheritdoc />
    public override RaidfmpPacket Move(IAnonymizer anonymizer, RaidfmpPacket packet)
        => packet with
        {
            HpSubPackets = packet.HpSubPackets.Select
            (
                x => x with
                {
                    PlayerId = anonymizer.AnonymizeId(x.PlayerId)
                }
            ).ToArray()
        };
}