using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Ursa.Controls;

namespace Darkmoon.Greatness.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private object? _content;
    private MenuItem? _selectedMenuItem;

    public MenuItem? SelectedMenuItem
    {
        get => _selectedMenuItem;
        set
        {
            SetProperty(ref _selectedMenuItem, value);
            OnNavigation(value);
        }
    }

    public object? Content
    {
        get => _content;
        set => SetProperty(ref _content, value);
    }


    public ObservableCollection<MenuItem> MenuItems { get; set; } = new()
    {
        new MenuItem
        {
            Header = "Ocr",
            IconName = "ocr",
            Children =
            {
                new MenuItem { Header = "竖排", IconName = "doc" },
                new MenuItem { Header = "横排", IconName = "docx" }
            }
        },
        new MenuItem
        {
            Header = "图像",
            IconName = "image",
        },
        new MenuItem { IsSeparator = true },
        new MenuItem { Header = "设置", IconName = "setting" },
        new MenuItem { IsSeparator = true }
    };

    private void OnNavigation(MenuItem? item)
    {
        Content = item!.Header switch
        {
            // "设置" => new SettingsPageViewModel()
        };
    }
}

public class MenuItem
{
    private static Random r = new();

    public MenuItem()
    {
        NavigationCommand = new AsyncRelayCommand(OnNavigate);
    }

    public string? Header { get; set; }
    public string IconName { get; set; }
    public bool IsSeparator { get; set; }
    public ICommand NavigationCommand { get; set; }

    public ObservableCollection<MenuItem> Children { get; set; } = new();

    private async Task OnNavigate()
    {
        await MessageBox.ShowOverlayAsync(Header ?? string.Empty, "Navigation result");
    }

    public IEnumerable<MenuItem> GetLeaves()
    {
        if (Children.Count == 0)
        {
            yield return this;
        }

        foreach (MenuItem child in Children)
        {
            var items = child.GetLeaves();
            foreach (MenuItem item in items)
            {
                yield return item;
            }
        }
    }
}