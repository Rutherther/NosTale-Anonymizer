//
//  PacketInfo.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.PacketSerializer.Abstractions.Attributes;

namespace Anonymizer;

/// <summary>
/// Information about a packet.
/// </summary>
/// <param name="Source"></param>
/// <param name="Packet"></param>
public record PacketInfo(PacketSource Source, string Packet);