using System.ComponentModel;
using System.Windows.Controls;
using WpfImageMemoryLeakDemo.Models;
using WpfImageMemoryLeakDemo.Views;
using Prism.Ioc;
using WpfImageMemoryLeakDemo.Mvvm;

namespace WpfImageMemoryLeakDemo.ViewModels;

internal sealed class MainWindowViewModel : MyBindableBase
{
    private static readonly ModelBoundary _boundary = App.Current.Model;
    private readonly IContainerExtension _container;

    public UserControl? ViewPanelSource
    {
        get => _viewPanelSource;
        private set => SetProperty(ref _viewPanelSource, value);
    }
    private UserControl? _viewPanelSource;

    public MainWindowViewModel(IContainerExtension container)
    {
        _container = container;
        _boundary.PropertyChanged += Boundary_PropertyChanged;
        ViewPanelSource = container.Resolve<BlankPanelView>();
    }

    private void Boundary_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(ModelBoundary.Bitmap))
            return;

        if (sender is not ModelBoundary boundary)
            return;

        ViewPanelSource = boundary.Bitmap is not null
            ? _container.Resolve<ImagePanelView>()
            : _container.Resolve<BlankPanelView>();
    }
}
