using GameLibrary.Model;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace GameLibrary.Controls
{
    public sealed partial class GameCard : UserControl
    {
        public GameCard()
        {
            InitializeComponent();
        }

        public Game? GameItem
        {
            get => (Game?)GetValue(GameItemProperty);
            set => SetValue(GameItemProperty, value);
        }

        public static readonly DependencyProperty GameItemProperty = 
            DependencyProperty.Register(
                nameof(GameItem),
                typeof(Game),
                typeof(GameCard),
                new PropertyMetadata(null));

        public event EventHandler? PlayRequested;
        public event EventHandler? DetailsRequested;

        private void CoverButton_Click(object sender, RoutedEventArgs e)
        {
            ShowActions();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            HideActions();
        }

        private void PlayButton_Click(Object sender, RoutedEventArgs e)
        {
            PlayRequested?.Invoke(this, EventArgs.Empty);
        }

        private void DetailsButton_Click(Object sender, RoutedEventArgs e)
        {
            DetailsRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ShowActions()
        {
            ActionPanel.IsHitTestVisible = true;
            VisualStateManager.GoToState(this, "ActionsVisible", true);
        }

        private void HideActions()
        {
            ActionPanel.IsHitTestVisible = false;
            VisualStateManager.GoToState(this, "Normal", true);
        }
    }
}
