//
//  CListPacketMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets.Server.Login;

namespace Anonymizer.Movers.Basic;

/// <inheritdoc />
public class CListPacketMover : AbstractMover<CListPacket>
{
    /// <inheritdoc />
    public override CListPacket Move(IAnonymizer anonymizer, CListPacket packet)
        => packet with
        {
            Name = anonymizer.AnonymizeName(packet.Name)
        };
}