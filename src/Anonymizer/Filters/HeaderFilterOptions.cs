//
//  HeaderFilterOptions.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Anonymizer.Filters;

/// <summary>
/// Options for <see cref="HeaderFilter"/>.
/// </summary>
public class HeaderFilterOptions
{
    /// <summary>
    /// Gets or sets the headers to remove. <see cref="KeepHeaders"/> is prioritized.
    /// </summary>
    public IReadOnlyList<string> RemoveHeaders { get; set; } = new[]
    {
        "mv",
        "stat",
        "say",
        "spk",
        "bn",
        "inv",

        "qslot",
        "umi",
        "msgi2",
        "qnai2",

        "die",

        "throw",

        "bf",
        "bf_e",
        "dm",
        "finit",
        "finfo",
        "ptctl",
        "suctl", // figure out what it does
        "ct", // figure out what it does
    };

    /// <summary>
    /// Gets or sets the headers to keep. Takes priority before remove headers.
    /// </summary>
    public IReadOnlyList<string>? KeepHeaders { get; set; } = null;

    // rdlst, raid, raidmbf, raidbf, in, out, c_info, c_mode
}