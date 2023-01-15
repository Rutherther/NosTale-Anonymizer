//
//  Program.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Anonymizer.Extensions;
using Anonymizer.Filters;
using Anonymizer.Sinks;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NosSmooth.PacketSerializer.Extensions;
using NosSmooth.PacketSerializer.Packets;

namespace Anonymizer.CLI;

/// <summary>
/// A main class.
/// </summary>
public static class Program
{
    /// <summary>
    /// A main method.
    /// </summary>
    /// <param name="args">The cli arguments.</param>
    /// <returns>The exit code.</returns>
    public static int Main(string[] args)
    {
        return Parser.Default.ParseArguments<Options>(args)
            .MapResult
            (
                options =>
                {
                    var directoryInfo = new DirectoryInfo(options.Output);
                    var fileInfo = new FileInfo(options.Output);
                    if (Directory.Exists(options.Output))
                    {
                        fileInfo = null;
                    }
                    else
                    {
                        directoryInfo = null;
                    }

                    return MakeAsync
                        (
                            new FileInfo(options.Input),
                            directoryInfo,
                            fileInfo,
                            new FileInfo(options.Config)
                        )
                        .GetAwaiter().GetResult();
                },
                _ => 1
            );
    }

    private static async Task<int> MakeAsync
    (
        FileInfo input,
        DirectoryInfo? outputDirectory,
        FileInfo? outputFile,
        FileInfo config
    )
    {
        if (!input.Exists)
        {
            Console.Error.WriteLine("The input file does not exist.");
            return 1;
        }

        if (outputFile is null)
        {
            outputFile = new FileInfo(Path.Join(outputDirectory!.FullName, input.Name));
        }

        if (outputFile.Exists)
        {
            Console.Error.WriteLine("The output file already exists.");
            return 1;
        }

        if (!config.Exists)
        {
            Console.Error.WriteLine($"The config file {config.FullName} does not exist.");
            return 1;
        }

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile(config.FullName)
            .Build();

        var services = new ServiceCollection()
            .Configure<HeaderFilterOptions>(configuration.GetSection("HeaderFilter"))
            .Configure<FileSinkOptions>(configuration.GetSection("PacketFile"))
            .AddPacketSerialization()
            .AddAnonymizer()
            .BuildServiceProvider();

        services.GetRequiredService<IPacketTypesRepository>().AddDefaultPackets();
        var processor = services.GetRequiredService<PacketProcessor>();
        using var fileSink = new FileSink
        (
            input.FullName,
            outputFile.FullName,
            services.GetRequiredService<IOptions<FileSinkOptions>>().Value
        );

        var result = await processor.ProcessSourceDestination(fileSink, fileSink);
        if (!result.IsSuccess)
        {
            Console.WriteLine(result.Error);
        }

        return 0;
    }
}