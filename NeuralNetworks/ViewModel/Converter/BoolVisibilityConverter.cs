﻿using System;
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
            if (value is bool boolValue && boolValue) 
            {
                return Visibility.Visible; 
            }
            else
            {
                return Visibility.Collapsed;
            }

        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility && visibility == Visibility.Visible)
            {
                return true;
            }
            return false;
        }
    }


}
