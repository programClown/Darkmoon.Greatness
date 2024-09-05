using System.Text.Json.Serialization;

namespace Darkmoon.Greatness.Core.Models;

[JsonConverter(typeof(JsonStringEnumConverter<LaunchOptionType>))]
public enum LaunchOptionType
{
    Bool,
    String,
    Int
}