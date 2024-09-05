using System.ComponentModel;

namespace Darkmoon.Greatness.Core.Models;

public class RelayPropertyChangedEventArgs : PropertyChangedEventArgs
{
    /// <inheritdoc />
    public RelayPropertyChangedEventArgs(string? propertyName, bool isRelay = false)
        : base(propertyName)
    {
        IsRelay = isRelay;
    }

    public bool IsRelay { get; }
}