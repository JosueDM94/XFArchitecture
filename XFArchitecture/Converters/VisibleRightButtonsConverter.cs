using System;
using System.Globalization;

using Xamarin.Forms;

using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Converters
{
    public class VisibleRightButtonsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var position = GetParameter(parameter);
                Console.WriteLine(position);
                if (value is RightButtons rightButtons)
                {
                    switch(rightButtons)
                    {
                        case RightButtons.None:
                            return false;
                        case RightButtons.One:
                            if (position.Equals(1))
                                return true;
                            return false;
                        case RightButtons.Two:
                            return true;
                    }
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
            if(parameter != null)
                return Int32.Parse(parameter.ToString());
            return 0;
        }
    }
}