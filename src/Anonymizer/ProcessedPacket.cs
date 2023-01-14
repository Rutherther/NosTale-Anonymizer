//
//  ProcessedPacket.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NosSmooth.Packets;

namespace Anonymizer;

public record ProcessedPacket(string OriginalPacketString, string NewPacketString, bool Keep);