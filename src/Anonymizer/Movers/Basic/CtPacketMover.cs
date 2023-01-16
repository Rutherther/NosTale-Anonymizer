//
//  CtPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Battle;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class CtPacketMover : AbstractMover<CtPacket>
{
    /// <inheritdoc />
    public override CtPacket Move(IAnonymizer anonymizer, CtPacket packet)
        => packet with
        {
            CasterEntityId = anonymizer.AnonymizeId(packet.CasterEntityId),
            TargetEntityId = packet.TargetEntityId is null ? null : anonymizer.AnonymizeId(packet.TargetEntityId.Value)
        };
}