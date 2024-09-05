﻿namespace Darkmoon.Greatness.Core.Helper.HardwareInfo;

public readonly record struct MemoryInfo
{
    public ulong TotalInstalledBytes { get; init; }

    public ulong TotalPhysicalBytes { get; init; }

    public ulong AvailablePhysicalBytes { get; init; }
}