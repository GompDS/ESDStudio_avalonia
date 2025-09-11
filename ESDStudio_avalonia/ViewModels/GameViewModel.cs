using System;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;

namespace ESDStudio_avalonia.ViewModels;

public class GameViewModel : ViewModelBase
{
    public static GameViewModel DarkSoulsWin64 { get; } = 
        new("ds1.jpg", "DARK SOULS", PlatformType.Win32);
    public static GameViewModel BloodbornePs4 { get; } = 
        new("bb.jpg", "BLOODBORNE", PlatformType.Ps4);
    public static GameViewModel DarkSoulsIIIWin64 { get; } = 
        new("ds3.jpg", "DARK SOULS III", PlatformType.Win64);
    public static GameViewModel DarkSoulsRemasteredWin64 { get; } = 
        new("ds1r.jpg", "DARK SOULS REMASTERED", PlatformType.Win64);
    public static GameViewModel SekiroWin64 { get; } = 
        new("sdt.jpg", "SEKIRO: SHADOWS DIE TWICE", PlatformType.Win64);
    public static GameViewModel EldenRingWin64 { get; } = 
        new("er.jpg", "ELDEN RING", PlatformType.Win64);
    public static GameViewModel ArmoredCoreVIFiresOfRubiconWin64 { get; } = 
        new("ac6.jpg", "ARMORED CORE VI: FIRES OF RUBICON", PlatformType.Win64);
    public static GameViewModel EldenRingNightreignWin64 { get; } = 
        new("nr.jpg", "ELDEN RING NIGHTREIGN", PlatformType.Win64);
    
    public GameViewModel() {}
    public GameViewModel(string iconName, string title, PlatformType platform)
    {
        Icon = new Bitmap(AssetLoader.Open(new Uri("avares://ESDStudio_avalonia/Assets/GameIcons/" + iconName)));
        Title = title;
        Platform = platform;
    }

    public enum PlatformType
    {
        Unk,
        Win32,
        Win64,
        Ps4,
    }
    
    private Bitmap _icon = new(AssetLoader.Open(new Uri("avares://ESDStudio_avalonia/Assets/GameIcons/unk.png")));
    public Bitmap Icon
    {
        get => _icon;
        set => this.RaiseAndSetIfChanged(ref _icon, value);
    }
    
    private string _title = "None";
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }
    
    private PlatformType _platform;
    public PlatformType Platform
    {
        get => _platform;
        set => this.RaiseAndSetIfChanged(ref _platform, value);
    }
}