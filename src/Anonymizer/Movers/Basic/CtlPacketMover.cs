//
//  CtlPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Mates;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class CtlPacketMover : AbstractMover<CtlPacket>
{
    /// <inheritdoc />
    public override CtlPacket Move(IAnonymizer anonymizer, CtlPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}