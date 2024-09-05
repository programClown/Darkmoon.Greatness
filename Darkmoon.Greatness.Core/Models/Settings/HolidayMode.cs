using System.Text.Json.Serialization;

namespace Darkmoon.Greatness.Core.Models.Settings;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum HolidayMode
{
    Automatic,
    Enabled,
    Disabled
}