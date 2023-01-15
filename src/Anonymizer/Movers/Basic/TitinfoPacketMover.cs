//
//  TitinfoPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Character;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class TitinfoPacketMover : AbstractMover<TitinfoPacket>
{
    /// <inheritdoc />
    public override TitinfoPacket Move(IAnonymizer anonymizer, TitinfoPacket packet)
        => packet with
        {
            CharacterId = anonymizer.AnonymizeId(packet.CharacterId)
        };
}