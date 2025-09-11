using Avalonia.ReactiveUI;
using ESDStudio_avalonia.ViewModels;

namespace ESDStudio_avalonia.Views;

public partial class MainWindow : ReactiveWindow<NewProjectWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }
}