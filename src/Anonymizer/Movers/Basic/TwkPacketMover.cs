//
//  TwkPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.UI;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class TwkPacketMover : AbstractMover<TwkPacket>
{
    /// <inheritdoc />
    public override TwkPacket Move(IAnonymizer anonymizer, TwkPacket packet)
        => packet with
        {
            AccountName = anonymizer.AnonymizeName(packet.AccountName),
            CharacterName = anonymizer.AnonymizeName(packet.CharacterName),
            EntityId = anonymizer.AnonymizeId(packet.EntityId),
            Salt = anonymizer.AnonymizeName(packet.Salt)
        };
}