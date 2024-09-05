﻿using System.Collections.Immutable;
using System.Text.RegularExpressions;
using Darkmoon.Greatness.Core.Extensions;

namespace Darkmoon.Greatness.Core.Python;

public partial record PipIndexResult
{
    public required IReadOnlyList<string> AvailableVersions { get; init; }

    public static PipIndexResult Parse(string output)
    {
        MatchCollection match = AvailableVersionsRegex().Matches(output);

        var versions = output
            .SplitLines()
            .Select(line => AvailableVersionsRegex().Match(line))
            .First(m => m.Success)
            .Groups["versions"].Value
            .Split(
                new[] { ',' },
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries
            )
            .ToImmutableArray();

        return new PipIndexResult { AvailableVersions = versions };
    }

    // Regex, capture the line starting with "Available versions:"
    [GeneratedRegex(@"^Available versions:\s*(?<versions>.*)$")]
    private static partial Regex AvailableVersionsRegex();
}