//
//  DropPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Maps;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class DropPacketMover : AbstractMover<DropPacket>
{
    /// <inheritdoc />
    public override DropPacket Move(IAnonymizer anonymizer, DropPacket packet)
        => packet with
        {
            DropId = anonymizer.AnonymizeId(packet.DropId)
        };
}