using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NeuralNetworks.ViewModel.Converter
{
    class IntStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int a)
            {
                return a.ToString();
            }
            else return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s)
            {
                int result;

                bool r = int.TryParse(s, out result);

                if (r)
                {
                    return result;
                }
                else return 0;
            }
            return 0;
        }
    }
}
