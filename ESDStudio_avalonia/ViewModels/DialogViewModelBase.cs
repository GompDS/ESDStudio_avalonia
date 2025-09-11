using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ESDStudio_avalonia.Views;
using ReactiveUI;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using MainWindow = ESDStudio_avalonia.Views.MainWindow;

namespace ESDStudio_avalonia.ViewModels;

public class DialogViewModelBase : ViewModelBase, IValidatableViewModel
{
    public bool DialogResult;

    public IValidationContext ValidationContext { get; } = new ValidationContext();

    public async Task<bool> ShowDialogWindow<T>() where T : Window, new()
    {
        if (Application.Current?.ApplicationLifetime is not 
            IClassicDesktopStyleApplicationLifetime { MainWindow: MainWindow mainWindow })
            return false;
        
        T window = new T
        {
            DataContext = this
        };
                
        
        await window.ShowDialog(mainWindow);
        return DialogResult;
    }
}