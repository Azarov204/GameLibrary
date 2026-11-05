using GameLibrary.Pages;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using System;
using Windows.UI;

namespace GameLibrary;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(typeof(LibraryPage));

        var appWindow = this.AppWindow;

        if (appWindow.Presenter is OverlappedPresenter presenter)
        {
            presenter.PreferredMinimumWidth = 1000;
            presenter.PreferredMinimumHeight = 600;
        }

        var titleBar = AppWindow.TitleBar;
        var backgroundColor = HexToColor("#312D44");
        var backgroundColorHover = HexToColor("#6E6699");

        titleBar.BackgroundColor = backgroundColor;
        titleBar.ForegroundColor = Colors.White;

        titleBar.ButtonBackgroundColor = backgroundColor;
        titleBar.ButtonForegroundColor = Colors.White;

        titleBar.ButtonHoverBackgroundColor = backgroundColorHover;
        titleBar.ButtonHoverForegroundColor = Colors.White;

        titleBar.ButtonPressedBackgroundColor = backgroundColorHover;
        titleBar.ButtonPressedForegroundColor = Colors.White;
    }

    private static Color HexToColor(string hex)
    {
        hex = hex.TrimStart('#');

        byte r = Convert.ToByte(hex.Substring(0, 2), 16);
        byte g = Convert.ToByte(hex.Substring(2, 2), 16);
        byte b = Convert.ToByte(hex.Substring(4, 2), 16);

        return Color.FromArgb(255, r, g, b);
    }
}