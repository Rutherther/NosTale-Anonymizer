//
//  Options.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CommandLine;

namespace Anonymizer.CLI;

/// <summary>
/// CLI Options.
/// </summary>
public class Options
{
    /// <summary>
    /// Gets or sets the input path.
    /// </summary>
    [Option('i', "input")]
    public string Input { get; set; } = "input.log";

    /// <summary>
    /// Gets or sets the output path.
    /// </summary>
    [Option('o', "output")]
    public string Output { get; set; } = "output.log";

    /// <summary>
    /// Gets or sets the config path.
    /// </summary>
    [Option('c', "config")]
    public string Config { get; set; } = "config.json";
}