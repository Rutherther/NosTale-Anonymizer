//
//  SayPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Chat;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class SayPacketMover : AbstractMover<SayPacket>
{
    /// <inheritdoc />
    public override SayPacket Move(IAnonymizer anonymizer, SayPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}