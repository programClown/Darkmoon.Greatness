using System.Windows.Input;

namespace Darkmoon.Greatness.Models;

public class ButtonItem
{
    public string? Name { get; set; }
    public string? Tips { get; set; }
    public ICommand? InvokeCommand { get; set; }
}