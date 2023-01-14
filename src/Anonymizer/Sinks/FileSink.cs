//
//  FileSink.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Text.RegularExpressions;
using NosSmooth.PacketSerializer.Abstractions.Attributes;

namespace Anonymizer.Sinks;

/// <summary>
/// A sink that supports reading from a file and writing to a file.
/// </summary>
public class FileSink : IDisposable, IPacketSource, IPacketDestination
{
    private readonly FileSinkOptions _options;
    private readonly FileStream _sourceStream;
    private readonly FileStream _destinationStream;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileSink"/> class.
    /// </summary>
    /// <param name="sourceFile">The source file path.</param>
    /// <param name="destinationFile">The destination file path.</param>
    /// <param name="options">The options.</param>
    public FileSink(string sourceFile, string destinationFile, FileSinkOptions options)
    {
        _options = options;
        _sourceStream = File.OpenRead(sourceFile);
        _destinationStream = File.OpenWrite(destinationFile);
    }

    /// <inheritdoc />
    public long Cursor { get; private set; }

    /// <inheritdoc />
    public Task<bool> TryGetNextPacketAsync(out PacketInfo packetInfo, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task WritePacketAsync(string packetString)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _sourceStream.Dispose();
        _destinationStream.Dispose();
    }
}