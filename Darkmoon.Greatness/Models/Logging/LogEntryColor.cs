using System.Drawing;

namespace Darkmoon.Greatness.Models.Logging;

public class LogEntryColor
{
    public LogEntryColor()
    {
    }

    public LogEntryColor(Color foreground, Color background)
    {
        Foreground = foreground;
        Background = background;
    }

    public Color Foreground { get; set; } = Color.Black;
    public Color Background { get; set; } = Color.Transparent;
}