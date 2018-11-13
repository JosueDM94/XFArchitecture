using System;
using System.Globalization;

using Xamarin.Forms;

using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Converters
{
    public class StyleErrorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = GetParameter(parameter);
            if (value != null && value is ErrorType errorType)
            {            
                switch (errorType)
                {
                    case ErrorType.Error:
                        return Application.Current.Resources["Error"+ color];
                    case ErrorType.Warning:
                        return Application.Current.Resources["Warning"+ color];
                    case ErrorType.Information:
                        return Application.Current.Resources["Information"+ color];
                }
            }
            return Application.Current.Resources["Error" + color];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        private string GetParameter(object parameter)
        {
            if (parameter != null)
                return parameter.ToString();
            return string.Empty;
        }
    }
}