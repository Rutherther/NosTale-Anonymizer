//
//  FileSinkOptions.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Text.RegularExpressions;

namespace Anonymizer.Sinks;

public record FileSinkOptions(Regex lineRegex, string recvString, string sendString);