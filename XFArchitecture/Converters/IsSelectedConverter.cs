using System;
using System.Globalization;

using Xamarin.Forms;

namespace XFArchitecture.Converters
{
    public class IsSelectedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var position = GetParameter(parameter);
                if (value is int index)
                {
                    if (index.Equals(position))
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