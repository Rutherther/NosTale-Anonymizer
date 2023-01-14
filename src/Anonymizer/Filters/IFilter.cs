//
//  IFilter.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Anonymizer.Filters;

/// <summary>
/// Filters packet strings.
/// </summary>
public interface IFilter
{
    /// <summary>
    /// Check the given string, return whether to keep it.
    /// </summary>
    /// <param name="packetInfo">The packet info to check.</param>
    /// <returns>Whether to keep the packet.</returns>
    public bool Filter(PacketInfo packetInfo);
}