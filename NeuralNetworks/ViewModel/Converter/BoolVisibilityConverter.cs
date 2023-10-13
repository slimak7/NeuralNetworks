using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NeuralNetworks.ViewModel.Converter
{
    class BoolVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType,
    object parameter, CultureInfo culture)
    {
        var booool = (bool)value;
        if (booool == false)
            return Visibility.Collapsed;
        else
            return Visibility.Visible;

    }

    public object ConvertBack(object value, Type targetType,
        object parameter, CultureInfo culture)
    {
        if (value is Visibility && (Visibility)value == Visibility.Visible)
        {
            return true;
        }
        return false;
    }
}
    
    
}
