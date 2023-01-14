//
//  CModePacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Character;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class CModePacketMover : AbstractMover<CModePacket>
{
    /// <inheritdoc />
    public override CModePacket Move(IAnonymizer anonymizer, CModePacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}