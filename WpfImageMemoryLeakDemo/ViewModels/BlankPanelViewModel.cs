using System.Windows.Input;
using WpfImageMemoryLeakDemo.Models;
using WpfImageMemoryLeakDemo.Mvvm;

namespace WpfImageMemoryLeakDemo.ViewModels;

internal sealed class BlankPanelViewModel : MyBindableBase
{
    private static readonly ModelBoundary _boundary = App.Current.Model;

    public ICommand OpenImageDirectoryCommand { get; }

    public BlankPanelViewModel()
    {
        OpenImageDirectoryCommand = new MyCommand(() => _boundary.LoadImage());
    }
}
