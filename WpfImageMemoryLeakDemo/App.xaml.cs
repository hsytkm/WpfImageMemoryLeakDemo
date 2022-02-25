using System.Windows;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;

namespace WpfImageMemoryLeakDemo;

public sealed partial class App : PrismApplication
{
    public static new App Current => (App)Application.Current;
    internal Models.ModelBoundary Model { get; } = new();

    protected override Window CreateShell() => Container.Resolve<Views.MainWindow>();

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
    }
}
