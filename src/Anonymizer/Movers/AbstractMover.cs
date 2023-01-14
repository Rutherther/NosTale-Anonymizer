//
//  AbstractMover.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets;

namespace Anonymizer.Movers;

/// <inheritdoc />
public abstract class AbstractMover<TPacket> : IMover<TPacket>
    where TPacket : IPacket
{
    /// <inheritdoc />
    public abstract TPacket Move(IAnonymizer anonymizer, TPacket packet);

    /// <inheritdoc />
    public bool ShouldHandle(IPacket packet)
        => packet is TPacket;

    /// <inheritdoc />
    public IPacket Move(IAnonymizer anonymizer, IPacket packet)
        => Move(anonymizer, (TPacket)packet);
}