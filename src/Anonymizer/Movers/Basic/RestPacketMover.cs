//
//  RestPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.UI;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class RestPacketMover : AbstractMover<RestPacket>
{
    /// <inheritdoc />
    public override RestPacket Move(IAnonymizer anonymizer, RestPacket packet)
        => packet with
        {
            EntityId = anonymizer.AnonymizeId(packet.EntityId)
        };
}