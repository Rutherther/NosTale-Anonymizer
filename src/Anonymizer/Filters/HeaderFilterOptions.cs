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
        "infoi",
        "msgi",
        "sayi",
        "sayi2",
        "sayitemt",
        "sayit",
        "sayit2",
        "bn",
        "inv",
        "qslot",
        "umi",
        "msgi2",
        "qnai2",
    };

    /// <summary>
    /// Gets or sets the headers to keep. Takes priority before remove headers.
    /// </summary>
    public IReadOnlyList<string>? KeepHeaders { get; set; } = null;
}