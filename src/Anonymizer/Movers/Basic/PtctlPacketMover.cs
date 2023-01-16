//
//  PtctlPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Client.Mates;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class PtctlPacketMover : AbstractMover<PtctlPacket>
{
    /// <inheritdoc />
    public override PtctlPacket Move(IAnonymizer anonymizer, PtctlPacket packet)
        => packet with
        {
            Controls = packet.Controls.Select
            (
                x => x with
                {
                    MateTransportId = anonymizer.AnonymizeId(x.MateTransportId)
                }
            ).ToArray()
        };
}