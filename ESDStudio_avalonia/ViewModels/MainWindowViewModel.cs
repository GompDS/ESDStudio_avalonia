using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using NewProjectWindow = ESDStudio_avalonia.Views.NewProjectWindow;

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
            if (!result) return;

            string projectDir = $"{vm.BaseDirectory}/{vm.Game.Title}/{vm.Game.Platform}/{vm.Name}";
            if (!Directory.Exists(projectDir))
            {
                Directory.CreateDirectory(projectDir);
            }
        }
        catch (Exception e)
        {
            throw new Exception("Failed to open new project window", e);
        }
    }
}