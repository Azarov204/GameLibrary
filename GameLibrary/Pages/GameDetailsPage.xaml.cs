using GameLibrary.Model;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Threading.Tasks;

namespace GameLibrary.Pages;

/// summary of page
public sealed partial class GameDetailsPage : Page
{
    private CanvasBitmap? _heroBitmap;
    private GaussianBlurEffect? _blurEffect;

    public GameDetailsPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        
        if (e.Parameter is Game game)
        {
            DataContext = game;
        }
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (Frame?.CanGoBack == true)
        {
            Frame.GoBack();
        }
    }

    private void HeroBlurCanvas_CreateResources(CanvasControl sender, CanvasCreateResourcesEventArgs args)
    {
        args.TrackAsyncAction(LoadHeroImageAsync(sender).AsAsyncAction());
    }

    private async Task LoadHeroImageAsync(CanvasControl sender)
    {
        // Replace this with the actual hero image URI.
        var imageUri = new Uri(
            "ms-appx:///Assets/GameHeros/cs2_hero.png");

        _heroBitmap = await CanvasBitmap.LoadAsync(sender, imageUri);

        _blurEffect = new GaussianBlurEffect
        {
            Source = _heroBitmap,
            BlurAmount = 50f,
            BorderMode = EffectBorderMode.Hard
        };

        HeroBlurCanvas.Invalidate();
    }

    private void HeroBlurCanvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
    {
        if (_blurEffect == null || _heroBitmap == null)
            return;

        float width = (float)sender.ActualWidth;
        float height = (float)sender.ActualHeight;

        if (width <= 0 || height <= 0)
            return;

        var scaleEffect = new ScaleEffect
        {
            Source = _blurEffect,
            Scale = new System.Numerics.Vector2(
                width / (float)_heroBitmap.Size.Width,
                height / (float)_heroBitmap.Size.Height)
        };

        args.DrawingSession.DrawImage(
            scaleEffect,
            new System.Numerics.Vector2(0, 0));
    }
}
