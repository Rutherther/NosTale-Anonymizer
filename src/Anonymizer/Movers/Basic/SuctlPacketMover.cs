//
//  SuctlPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Client.Mates;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class SuctlPacketMover : AbstractMover<SuctlPacket>
{
    /// <inheritdoc />
    public override SuctlPacket Move(IAnonymizer anonymizer, SuctlPacket packet)
        => packet with
        {
            MateTransportId = anonymizer.AnonymizeId(packet.MateTransportId),
            TargetId = anonymizer.AnonymizeId(packet.TargetId)
        };
}