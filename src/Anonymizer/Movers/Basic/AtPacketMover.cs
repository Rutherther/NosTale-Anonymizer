//
//  AtPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Maps;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class AtPacketMover : AbstractMover<AtPacket>
{
    /// <inheritdoc />
    public override AtPacket Move(IAnonymizer anonymizer, AtPacket packet)
        => packet with
        {
            CharacterId = anonymizer.AnonymizeId(packet.CharacterId)
        };
}