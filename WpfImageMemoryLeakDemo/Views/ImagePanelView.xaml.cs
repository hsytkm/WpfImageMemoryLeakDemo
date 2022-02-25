using System.Windows.Controls;

namespace WpfImageMemoryLeakDemo.Views;

// Inherit IDisposable to UserControl causes
// a memory leak of Image control. Why??
// UserControl に IDisposable を継承すると、
// Imageコントロールがメモリリークします。なぜ??
public partial class ImagePanelView : UserControl, IDisposable
{
    public ImagePanelView() => InitializeComponent();

    public void Dispose() { }
}
