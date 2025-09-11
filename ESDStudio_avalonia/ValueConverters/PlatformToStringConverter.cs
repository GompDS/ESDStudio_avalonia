using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;
using ESDStudio_avalonia.ViewModels;

namespace ESDStudio_avalonia.ValueConverters;

public class PlatformToStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is GameViewModel.PlatformType platform)
        {
            switch (platform)
            {
                case GameViewModel.PlatformType.Win32: return " x32";
                case GameViewModel.PlatformType.Win64: return " x64";
                case GameViewModel.PlatformType.Ps4: return " PS4";
                default: return "";
            }
        }
        
        return new BindingNotification(new InvalidCastException(), 
            BindingErrorType.Error);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}