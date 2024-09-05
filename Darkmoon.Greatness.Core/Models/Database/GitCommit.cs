﻿using System.Text.Json.Serialization;

namespace Darkmoon.Greatness.Core.Models.Database;

public class GitCommit
{
    public string? Sha { get; set; }

    [JsonIgnore]
    public string ShortSha => string.IsNullOrWhiteSpace(Sha) ? string.Empty : Sha[..7];
}