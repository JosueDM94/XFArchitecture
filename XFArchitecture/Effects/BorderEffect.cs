using System.Linq;
using Xamarin.Forms;

namespace XFArchitecture.Effects
{
    public class BorderEffect : RoutingEffect
    {
        #region Bindables Properties
        public int BorderWidth { get; set; } = 0;

        public int BorderRadius { get; set; } = 0;

        public static readonly BindableProperty BorderColorProperty = BindableProperty.CreateAttached("BorderColor", typeof(Color), typeof(BorderEffect), Color.Default, BindingMode.TwoWay, propertyChanged: OnPropertyChanged);

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

        static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if ((bindable is View view) && newValue != null)
            //SetBorderColor(view, (Color)newValue);
            //if (!(bindable is View view)) return;
            //if (newValue != null)
            //{
            //    view.Effects.Add(new BorderEffect());
            //}
            //else
            //{
            //    var toRemove = view.Effects.FirstOrDefault(e => e is BorderEffect);
            //    if (toRemove != null)
            //    {
            //        view.Effects.Remove(toRemove);
            //    }
            //}
        }
    }
}