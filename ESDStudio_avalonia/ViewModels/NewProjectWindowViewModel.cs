using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Platform.Storage;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;

namespace ESDStudio_avalonia.ViewModels;

public class NewProjectWindowViewModel : DialogViewModelBase
{
    public NewProjectWindowViewModel()
    {
        this.ValidationRule(
            viewModel => viewModel.Name,
            name => !string.IsNullOrWhiteSpace(name) && 
                    !name.Any(c => c is '<' or '>' or ':' or '"' or '/' or '\\' or '|' or '?' or '*' or '#'),
            "Name cannot be empty or contain invalid characters.");
        this.ValidationRule(
            viewModel => viewModel.BaseDirectory,
            dir => !string.IsNullOrWhiteSpace(dir) && Directory.Exists(dir),
            "Base Directory must be an existing directory.");
        this.ValidationRule(
            viewModel => viewModel.Game,
            game => !_validGames.Contains(game),
            "You must specify a game for the project.");
        this.ValidationRule(
            viewModel => viewModel.GameDataDirectory,
            dir => !string.IsNullOrWhiteSpace(dir) && Directory.Exists(dir),
            "Game Data Directory must be an existing directory.");
        this.ValidationRule(
            viewModel => viewModel.BuildDirectory,
            dir => !string.IsNullOrWhiteSpace(dir) && Directory.Exists(dir),
            "Build Directory must be an existing directory.");
        
        BrowseBaseDirectoryCmd =  ReactiveCommand.CreateFromTask(BrowseBaseDirectory);
        BrowseGameDataDirectoryCmd = ReactiveCommand.CreateFromTask(BrowseGameDataDirectory);
        BrowseBuildDirectoryCmd = ReactiveCommand.CreateFromTask(BrowseBuildDirectory);
    }

    private static readonly string[] _validGames = new[]
    {
        "DARK SOULS: PREPARE TO DIE EDITION (PC)",
        "DARK SOULS REMASTERED (PC)",
        "BLOODBORNE (PS4)",
        "DARK SOULS III (PC)",
        "SEKIRO: SHADOWS DIE TWICE (PC)",
        "ELDEN RING (PC)",
        "ARMORED CORE VI: FIRES OF RUBICON (PC)",
        "ELDEN RING NIGHTREIGN (PC)"
    };

    private string _name;
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    
    private string _baseDirectory;
    public string BaseDirectory
    {
        get => _baseDirectory;
        set => this.RaiseAndSetIfChanged(ref _baseDirectory, value);
    }
    
    private string _game;
    public string Game
    {
        get => _game;
        set => this.RaiseAndSetIfChanged(ref _game, value);
    }
    
    private string _gameDataDirectory;
    public string GameDataDirectory
    {
        get => _gameDataDirectory;
        set => this.RaiseAndSetIfChanged(ref _gameDataDirectory, value);
    }
    
    private string _buildDirectory;
    public string BuildDirectory
    {
        get => _buildDirectory;
        set => this.RaiseAndSetIfChanged(ref _buildDirectory, value);
    }
    
    private bool _importCustomBinaries;
    public bool ImportCustomBinaries
    {
        get => _importCustomBinaries;
        set => this.RaiseAndSetIfChanged(ref _importCustomBinaries, value);
    }
    
    public ICommand BrowseBaseDirectoryCmd { get; }
    public ICommand BrowseGameDataDirectoryCmd { get; }
    public ICommand BrowseBuildDirectoryCmd { get; }

    private async Task BrowseBaseDirectory()
    {
        IReadOnlyList<IStorageFolder> folders = await PickFolders();
        if (folders.Count > 0)
        {
            BaseDirectory = folders[0].Path.AbsolutePath.Replace("%20", " ");
        }
    }
    
    private async Task BrowseGameDataDirectory()
    {
        IReadOnlyList<IStorageFolder> folders = await PickFolders();
        if (folders.Count > 0)
        {
            GameDataDirectory = folders[0].Path.AbsolutePath.Replace("%20", " ");
        }
    }
    
    private async Task BrowseBuildDirectory()
    {
        IReadOnlyList<IStorageFolder> folders = await PickFolders();
        if (folders.Count > 0)
        {
            BuildDirectory = folders[0].Path.AbsolutePath.Replace("%20", " ");
        }
    }
}