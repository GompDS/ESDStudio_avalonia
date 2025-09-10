using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using ESDStudio_avalonia.Views;
using ReactiveUI;

namespace ESDStudio_avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        OpenNewProjectWindowCmd = ReactiveCommand.CreateFromTask(OpenNewProjectWindow);
    }

    public ICommand OpenNewProjectWindowCmd { get; }

    private static async Task OpenNewProjectWindow()
    {
        try
        {
            NewProjectWindowViewModel vm = new();
            bool result = await vm.ShowDialogWindow<NewProjectWindow>();
        }
        catch (Exception e)
        {
            throw new Exception("Failed to open new project window", e);
        }
    }
}