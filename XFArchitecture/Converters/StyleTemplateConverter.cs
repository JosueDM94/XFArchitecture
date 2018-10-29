using System;
using System.Globalization;

using Xamarin.Forms;

using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Converters
{
    public class StyleTemplateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if(value is NavigationBarStyle)
                {
                    switch ((NavigationBarStyle)value)
                    {
                        case NavigationBarStyle.BackBar:
                            return Application.Current.Resources["BackBar"];
                        case NavigationBarStyle.MenuBar:
                            return Application.Current.Resources["MenuBar"];
                        case NavigationBarStyle.TitleBar:
                            return Application.Current.Resources["TitleBar"];
                        case NavigationBarStyle.SearchBar:
                            return Application.Current.Resources["SearchBar"];
                        case NavigationBarStyle.CustomBar:
                            return Application.Current.Resources["CustomBar"];
                    } 
                }
            }
            return Application.Current.Resources["BackBar"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}