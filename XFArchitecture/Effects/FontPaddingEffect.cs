using System.Linq;

using Xamarin.Forms;

namespace XFArchitecture.Effects
{
    public class FontPaddingEffect : RoutingEffect
    {
        #region Bindables Properties
        public static readonly BindableProperty IncludeFontPaddingProperty = BindableProperty.CreateAttached("IncludeFontPadding", typeof(bool?), typeof(FontPaddingEffect), null, propertyChanged: PropertyChanged);

        public static bool? GetIncludeFontPadding(BindableObject view)
        {
            return (bool?)view.GetValue(IncludeFontPaddingProperty);
        }

        public static void SetIncludeFontPadding(BindableObject view, bool? value)
        {
            view.SetValue(IncludeFontPaddingProperty, value);
        }
        #endregion

        public FontPaddingEffect() : base("com.itexico.XFArchitecture.FontPaddingEffect")
        {
        }

        private static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is View view)) return;
            var effect = view.Effects.FirstOrDefault(e => e is FontPaddingEffect);
            if (GetIncludeFontPadding(bindable) != null && effect == null)
                view.Effects.Add(new FontPaddingEffect());
            else
            {
                if (effect != null && view.BindingContext != null)
                {
                    view.Effects.Remove(effect);
                }
            }
        }
    }
}