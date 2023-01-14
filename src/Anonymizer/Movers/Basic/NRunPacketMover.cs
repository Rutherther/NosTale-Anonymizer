//
//  NRunPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Client;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class NRunPacketMover : AbstractMover<NRunPacket>
{
    /// <inheritdoc />
    public override NRunPacket Move(IAnonymizer anonymizer, NRunPacket packet)
        => packet with
        {
            EntityId = packet.EntityId
        };
}