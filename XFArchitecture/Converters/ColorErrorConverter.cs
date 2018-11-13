using System;
using System.Globalization;

using Xamarin.Forms;

using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Converters
{
    public class ColorErrorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is ErrorType errorType)
            {            
                switch (errorType)
                {
                    case ErrorType.Error:
                        return Application.Current.Resources["ErrorColor"];
                    case ErrorType.Sucess:
                        return Application.Current.Resources["SucessColor"];
                    case ErrorType.Warning:
                        return Application.Current.Resources["WarningColor"];
                    case ErrorType.Information:
                        return Application.Current.Resources["InformationColor"];
                }
            }
            return Application.Current.Resources["ErrorColor"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}