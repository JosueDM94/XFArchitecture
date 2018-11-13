using System.Linq;
using Xamarin.Forms;

namespace XFArchitecture.Effects
{
    public class BorderEffect : RoutingEffect
    {
        #region Bindables Properties
        public int BorderWidth { get; set; } = 0;

        public int BorderRadius { get; set; } = 0;

        public static readonly BindableProperty BorderColorProperty = BindableProperty.CreateAttached("BorderColor", typeof(Color), typeof(BorderEffect), Color.Default, BindingMode.TwoWay);

        public static Color GetBorderColor(BindableObject view)
        {
            return (Color)view.GetValue(BorderColorProperty);
        }

        public static void SetBorderColor(BindableObject view, Color value)
        {
            view.SetValue(BorderColorProperty, value);
        }
        #endregion

        public BorderEffect() : base("com.itexico.XFArchitecture.BorderEffect")
        {
        }
    }
}