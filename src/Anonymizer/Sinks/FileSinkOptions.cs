//
//  FileSinkOptions.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Text.RegularExpressions;

namespace Anonymizer.Sinks;

/// <summary>
/// Options for <see cref="FileSink"/>.
/// </summary>
public class FileSinkOptions
{
    /// <summary>
    /// Gets or sets the line format to output.
    /// </summary>
    public string OutputFormat { get; set; } = "[%TYPE%]\t%PACKET%";

    /// <summary>
    /// Gets or sets the regex match of the line.
    /// </summary>
    public string LineRegex { get; set; } = ".*\\[(Recv|Send)\\]\t(.*)";

    /// <summary>
    /// Gets or sets the receive string from the packet line.
    /// </summary>
    public string RecvString { get; set; } = "Recv";

    /// <summary>
    /// Gets or sets the send string from the packet line.
    /// </summary>
    public string SendString { get; set; } = "Send";
}