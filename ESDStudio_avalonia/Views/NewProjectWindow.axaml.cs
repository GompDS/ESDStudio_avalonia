using System.Reactive.Disposables;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ESDStudio_avalonia.ViewModels;
using ReactiveUI.Validation.Extensions;
using ReactiveUI;

namespace ESDStudio_avalonia.Views;

public partial class NewProjectWindow : ReactiveWindow<NewProjectWindowViewModel>
{
    public NewProjectWindow()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            this.Bind(ViewModel, vm => vm.Name, 
                view => view.NameTextBox.Text).DisposeWith(disposables);
            this.BindValidation(ViewModel, vm => vm.Name,
                view => view.NameErrorLabel.Content).DisposeWith(disposables);
            
            this.Bind(ViewModel, vm => vm.BaseDirectory, 
                view => view.BaseDirectoryTextBox.Text).DisposeWith(disposables);
            this.BindValidation(ViewModel, vm => vm.BaseDirectory,
                view => view.BaseDirectoryErrorLabel.Content).DisposeWith(disposables);
            
            this.Bind(ViewModel, vm => vm.GameDataDirectory, 
                view => view.GameDataDirectoryTextBox.Text).DisposeWith(disposables);
            this.BindValidation(ViewModel, vm => vm.GameDataDirectory,
                view => view.GameDataDirectoryErrorLabel.Content).DisposeWith(disposables);
            
            this.Bind(ViewModel, vm => vm.BuildDirectory, 
                view => view.BuildDirectoryTextBox.Text).DisposeWith(disposables);
            this.BindValidation(ViewModel, vm => vm.BuildDirectory,
                view => view.BuildDirectoryErrorLabel.Content).DisposeWith(disposables);
        });
    }

    private void ConfirmButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is NewProjectWindowViewModel vm)
        {
            vm.DialogResult = true;
        }
        Close();
    }

    private void CancelCommand_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}