using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using WpfImageMemoryLeakDemo.Mvvm;

namespace WpfImageMemoryLeakDemo.Models;

internal sealed class ModelBoundary : MyBindableBase
{
    private static readonly Uri _imageUri = new ("pack://application:,,,/WpfImageMemoryLeakDemo;component/Assets/image1.jpg");

    public BitmapSource? Bitmap
    {
        get => _bitmap;
        private set => SetProperty(ref _bitmap, value);
    }
    private BitmapSource? _bitmap;

    public void LoadImage()
    {
        if (Bitmap is null)
        {
            using var stream = Application.GetResourceStream(_imageUri).Stream;
            Bitmap = ToBitmapSource(stream);
        }
    }
    public void ClearImage() => Bitmap = null;

    private static BitmapSource? ToBitmapSource(Stream stream)
    {
        var image = new BitmapImage();
        image.BeginInit();
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.StreamSource = stream;
        image.EndInit();
        image.Freeze();
        return image;
    }
}
