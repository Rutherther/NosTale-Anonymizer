//
//  SuPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Battle;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class SuPacketMover : AbstractMover<SuPacket>
{
    /// <inheritdoc />
    public override SuPacket Move(IAnonymizer anonymizer, SuPacket packet)
        => packet with
        {
            CasterEntityId = anonymizer.AnonymizeId(packet.CasterEntityId),
            TargetEntityId = anonymizer.AnonymizeId(packet.TargetEntityId)
        };
}