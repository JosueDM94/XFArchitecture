using System;
using System.Globalization;

using Xamarin.Forms;

namespace XFArchitecture.Converters
{
    public class StepCompletedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var index = GetParameter(parameter);
                if (value is int position)
                {
                    if (index < position)
                        return true;
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private int GetParameter(object parameter)
        {
            if (parameter != null)
                return Int32.Parse(parameter.ToString());
            return int.MaxValue;
        }
    }
}