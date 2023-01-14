//
//  BsPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using NosSmooth.Packets.Server.Battle;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class BsPacketMover : AbstractMover<BsPacket>
{
    /// <inheritdoc />
    public override BsPacket Move(IAnonymizer anonymizer, BsPacket packet)
        => packet with
        {
            CasterEntityId = anonymizer.AnonymizeId(packet.CasterEntityId)
        };
}