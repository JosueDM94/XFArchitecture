using System;
using System.Globalization;

using Xamarin.Forms;

namespace XFArchitecture.Converters
{
    public class IsCenteredConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is LayoutOptions layoutOptions)
                {
                    if (layoutOptions.Equals(LayoutOptions.Center) || layoutOptions.Equals(LayoutOptions.CenterAndExpand))
                        return true;
                }
                if (value is LayoutAlignment layoutAlignment)
                {
                    if (layoutAlignment.Equals(LayoutAlignment.Center))
                        return true;
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
