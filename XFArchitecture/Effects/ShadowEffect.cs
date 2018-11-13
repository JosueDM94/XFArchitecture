using System;
using System.Linq;

using Xamarin.Forms;

namespace XFArchitecture.Effects
{
    public class ShadowEffect : RoutingEffect
    {
        #region Bindables Properties
        public static readonly BindableProperty HasShadowProperty = BindableProperty.CreateAttached("HasShadow", typeof(bool), typeof(ShadowEffect), false, propertyChanged: OnHasShadowChanged);

        public static bool GetHasShadow(BindableObject view)
        {
            return (bool)view.GetValue(HasShadowProperty);
        }

        public static void SetHasShadow(BindableObject view, bool value)
        {
            view.SetValue(HasShadowProperty, value);
        }
        #endregion

        public ShadowEffect() : base("com.itexico.XFArchitecture.ShadowEffect")
        {
        }

        private static void OnHasShadowChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is View view)) return;
            var effect = view.Effects.FirstOrDefault(e => e is ShadowEffect);
            if (effect == null)
                view.Effects.Add(new ShadowEffect());
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