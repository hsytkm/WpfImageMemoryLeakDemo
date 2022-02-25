using System.Windows.Input;

namespace WpfImageMemoryLeakDemo.Mvvm;

internal sealed class MyCommand : ICommand
{
    private readonly Action _action;
    private readonly Func<bool>? _canExecute;

    public event EventHandler? CanExecuteChanged;

    public MyCommand(Action execute, Func<bool>? canExecute = null)
        => (_action, _canExecute) = (execute, canExecute);

    public void Execute(object? parameter) => _action();

    public bool CanExecute(object? parameter) => (_canExecute is null) || _canExecute();

    public void ChangeCanExecute() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
