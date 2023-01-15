//
//  NcifPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Client.Battle;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class NcifPacketMover : AbstractMover<NcifPacket>
{
    /// <inheritdoc />
    public override NcifPacket Move(IAnonymizer anonymizer, NcifPacket packet)
        => packet with
        {
            TargetId = anonymizer.AnonymizeId(packet.TargetId)
        };
}