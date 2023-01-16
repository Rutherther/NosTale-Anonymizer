//
//  SayiPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Chat;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class SayiPacketMover : AbstractMover<SayiPacket>
{
    /// <inheritdoc />
    public override SayiPacket Move(IAnonymizer anonymizer, SayiPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}