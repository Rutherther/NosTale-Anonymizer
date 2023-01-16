//
//  SaytPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Chat;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class SaytPacketMover : AbstractMover<SaytPacket>
{
    /// <inheritdoc />
    public override SaytPacket Move(IAnonymizer anonymizer, SaytPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId),
            Name = anonymizer.AnonymizeName(packet.Name)
        };
}