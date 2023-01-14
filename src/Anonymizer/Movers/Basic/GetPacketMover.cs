//
//  GetPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Client.Inventory;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class GetPacketMover : AbstractMover<GetPacket>
{
    /// <inheritdoc />
    public override GetPacket Move(IAnonymizer anonymizer, GetPacket packet)
        => packet with
        {
            GroundItemId = anonymizer.AnonymizeId(packet.GroundItemId),
            PickerEntityId = anonymizer.AnonymizeId(packet.PickerEntityId)
        };
}