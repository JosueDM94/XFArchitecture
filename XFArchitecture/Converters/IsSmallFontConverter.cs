using System;
using System.Globalization;

using Xamarin.Forms;

namespace XFArchitecture.Converters
{
    public class IsSmallFontConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                if(value is string key)
                {
                    if (key.Equals(Application.Current.Resources["Save"]))
                           return 20;
                }
            }
            return 18;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}