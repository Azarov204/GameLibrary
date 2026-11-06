using GameLibrary.Model;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Threading.Tasks;

namespace GameLibrary.Views;

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
        args.TrackAsyncAction(LoadBlurHeroImageAsync(sender).AsAsyncAction());
    }

    private async Task LoadBlurHeroImageAsync(CanvasControl sender)
    {
        _heroBitmap = null;
        _blurEffect = null;

        if (DataContext is not Game game ||
            string.IsNullOrWhiteSpace(game.HeroImageUri))
        {
            HeroBlurCanvas.Invalidate();
            return;
        }

        try
        {
            var imageUri = new Uri(game.HeroImageUri);

            _heroBitmap = await CanvasBitmap.LoadAsync(sender, imageUri);

            _blurEffect = new GaussianBlurEffect
            {
                Source = _heroBitmap,
                BlurAmount = 40f,
                BorderMode = EffectBorderMode.Hard
            };
        }
        catch (Exception ex)
        {
            // Image is missing, invalid, or could not be loaded.
            _heroBitmap = null;
            _blurEffect = null;
        }
    }

    private void HeroBlurCanvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
    {
        if (_heroBitmap == null)
            return;

        float width = (float)sender.ActualWidth;
        float height = (float)sender.ActualHeight;

        if (width <= 0 || height <= 0)
            return;

        if (_blurEffect != null)
        {
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

        args.DrawingSession.FillRectangle(
            new Windows.Foundation.Rect(0, 0, width, height),
            Windows.UI.Color.FromArgb(0x44, 0, 0, 0));

        HeroImage_Draw(sender, args);
    }

    private void HeroImage_Draw(CanvasControl sender, CanvasDrawEventArgs args)
    {
        if (_heroBitmap == null)
            return;

        float width = (float)sender.ActualWidth;
        float height = (float)sender.ActualHeight;

        if (width <= 0 || height <= 0)
            return;

        float scale = Math.Min(
            width / (float)_heroBitmap.Size.Width,
            height / (float)_heroBitmap.Size.Height);
        float imageWidth = (float)_heroBitmap.Size.Width * scale;
        float imageHeight = (float)_heroBitmap.Size.Height * scale;
        float x = (width - imageWidth) / 2;
        float y = (height - imageHeight) / 2;

        float bitmapWidth = (float)_heroBitmap.Size.Width;
        float bitmapHeight = (float)_heroBitmap.Size.Height;

        using var mask = new CanvasCommandList(sender);
        using (var maskDrawingSession = mask.CreateDrawingSession())
        using (var gradientBrush = new CanvasLinearGradientBrush(sender, new[]
        {
            new CanvasGradientStop
            {
                Position = 0f,
                Color = Windows.UI.Color.FromArgb(0, 255, 255, 255)
            },
            new CanvasGradientStop
            {
                Position = 0.15f,
                Color = Windows.UI.Color.FromArgb(255, 255, 255, 255)
            },
            new CanvasGradientStop
            {
                Position = 0.85f,
                Color = Windows.UI.Color.FromArgb(255, 255, 255, 255)
            },
            new CanvasGradientStop
            {
                Position = 1f,
                Color = Windows.UI.Color.FromArgb(0, 255, 255, 255)
            }
        }))
        {
            gradientBrush.StartPoint = new System.Numerics.Vector2(0, 0);
            gradientBrush.EndPoint = new System.Numerics.Vector2(bitmapWidth, 0);
            maskDrawingSession.FillRectangle(
                new Windows.Foundation.Rect(0, 0, bitmapWidth, bitmapHeight),
                gradientBrush);
        }

        var fadedHeroImage = new AlphaMaskEffect
        {
            Source = _heroBitmap,
            AlphaMask = mask
        };

        var sharpImageScaleEffect = new ScaleEffect
        {
            Source = fadedHeroImage,
            Scale = new System.Numerics.Vector2(scale, scale)
        };

        args.DrawingSession.DrawImage(
            sharpImageScaleEffect,
            new System.Numerics.Vector2(x, y));
    }
}
