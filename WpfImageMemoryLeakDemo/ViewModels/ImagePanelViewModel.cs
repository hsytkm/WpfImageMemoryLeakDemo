using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfImageMemoryLeakDemo.Models;
using WpfImageMemoryLeakDemo.Mvvm;

namespace WpfImageMemoryLeakDemo.ViewModels;

internal sealed class ImagePanelViewModel : MyBindableBase
{
    private static readonly ModelBoundary _boundary = App.Current.Model;

    public BitmapSource? MyImage { get; }
    public ICommand CloseImageDirectoryCommand { get; }

    public ImagePanelViewModel()
    {
        MyImage = _boundary.Bitmap;
        CloseImageDirectoryCommand = new MyCommand(_boundary.ClearImage);
    }
}
