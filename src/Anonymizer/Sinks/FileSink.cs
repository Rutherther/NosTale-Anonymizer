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
    private readonly Regex _regex;
    private readonly FileSinkOptions _options;
    private readonly StreamReader _reader;
    private readonly StreamWriter _writer;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileSink"/> class.
    /// </summary>
    /// <param name="sourceFile">The source file path.</param>
    /// <param name="destinationFile">The destination file path.</param>
    /// <param name="options">The options.</param>
    public FileSink(string sourceFile, string destinationFile, FileSinkOptions options)
    {
        _regex = new Regex(options.LineRegex);
        _options = options;

        _reader = new StreamReader(File.OpenRead(sourceFile));
        _writer = new StreamWriter(File.OpenWrite(destinationFile));
    }

    /// <inheritdoc />
    public long Cursor { get; private set; }

    /// <inheritdoc />
    public async Task<PacketInfo?> TryGetNextPacketAsync(CancellationToken ct = default)
    {
        if (_reader.EndOfStream)
        {
            return null;
        }

        var line = await _reader.ReadLineAsync(ct);
        if (string.IsNullOrEmpty(line))
        {
            return null;
        }

        Cursor++;

        var match = _regex.Match(line);
        if (!match.Success)
        {
            Console.Error.WriteLine($"Could not find match on line {line}");
            return new PacketInfo(PacketSource.Client, string.Empty);
        }

        var type = match.Groups[1].Value;
        var packetStr = match.Groups[2].Value;
        var source = type == _options.RecvString ? PacketSource.Server : PacketSource.Client;

        return new PacketInfo(source, packetStr);
    }

    /// <inheritdoc />
    public async Task WritePacketAsync(PacketInfo packet, CancellationToken ct = default)
    {
        var output = _options.OutputFormat
            .Replace("%TYPE%", packet.Source == PacketSource.Client ? _options.SendString : _options.RecvString)
            .Replace("%PACKET%", packet.Packet);

        await _writer.WriteLineAsync(new ReadOnlyMemory<char>(output.ToCharArray()), ct);
        await _writer.FlushAsync();
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _writer.Dispose();
        _reader.Dispose();
    }
}