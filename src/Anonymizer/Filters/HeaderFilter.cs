//
//  HeaderFilter.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Options;

namespace Anonymizer.Filters;

/// <inheritdoc />
public class HeaderFilter : IFilter
{
    private readonly HeaderFilterOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="HeaderFilter"/> class.
    /// </summary>
    /// <param name="options">The header filter options.</param>
    public HeaderFilter(IOptions<HeaderFilterOptions> options)
    {
        _options = options.Value;
    }

    /// <inheritdoc />
    public bool Filter(PacketInfo packetInfo)
    {
        var splitted = packetInfo.Packet.Split(' ');
        if (splitted.Length < 1)
        {
            return true;
        }

        var header = splitted[0];
        return !_options.RemoveHeaders.Contains(header);
    }
}