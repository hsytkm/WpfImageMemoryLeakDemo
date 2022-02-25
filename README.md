# WpfImageMemoryLeakDemo



Inherit IDisposable to UserControl causes a memory leak of Image control. Why??

UserControl に IDisposable を継承すると、Imageコントロールがメモリリークします。なぜ??



![demo.gif](https://github.com/hsytkm/WpfImageMemoryLeakDemo/blob/master/demo.gif)