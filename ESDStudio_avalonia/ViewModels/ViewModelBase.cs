using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using ESDStudio_avalonia.Views;
using ReactiveUI;

namespace ESDStudio_avalonia.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public static async Task<IReadOnlyList<IStorageFile>> PickFiles(
        string fileTypeName,
        string[] patterns,
        bool allowMultiple = false)
    {
        if (Application.Current?.ApplicationLifetime is not 
            IClassicDesktopStyleApplicationLifetime { MainWindow: MainWindow mainWindow })
            return new List<IStorageFile>();

        return await mainWindow.StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                AllowMultiple = allowMultiple,
                FileTypeFilter = [
                    new FilePickerFileType(fileTypeName)
                    {
                        Patterns = patterns,
                    }
                ]
            });
    }
    
    public static async Task<IReadOnlyList<IStorageFolder>> PickFolders(bool allowMultiple = false)
    {
        if (Application.Current?.ApplicationLifetime is not 
            IClassicDesktopStyleApplicationLifetime { MainWindow: MainWindow mainWindow })
            return new List<IStorageFolder>();

        return await mainWindow.StorageProvider.OpenFolderPickerAsync(
            new FolderPickerOpenOptions
            {
                AllowMultiple = allowMultiple
            });
    }
}