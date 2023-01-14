//
//  RdlstPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Raids;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class RdlstPacketMover : AbstractMover<RdlstPacket>
{
    /// <inheritdoc />
    public override RdlstPacket Move(IAnonymizer anonymizer, RdlstPacket packet)
        => packet with
        {
            Players = packet.Players.Select
                (
                    p => p with
                    {
                        Id = anonymizer.AnonymizeId(p.Id),
                        Name = anonymizer.AnonymizeName(p.Name)
                    }
                )
                .ToArray()
        };
}