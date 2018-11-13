using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using XFArchitecture.iOS.Effects;
using XFArchitecture.iOS.Extensions;

[assembly: ExportEffect(typeof(ShadowEffect), nameof(ShadowEffect))]
namespace XFArchitecture.iOS.Effects
{
    public class ShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                UpdateShadow();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: " + ex.Message);
            }
        }

        protected override void OnDetached()
        {

        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            if (args.PropertyName.Equals(XFArchitecture.Effects.ShadowEffect.HasShadowProperty.PropertyName))
                UpdateShadow();
        }

        private void UpdateShadow()
        {
            var view = Control ?? Container;
            if(view != null)
            {
                if (XFArchitecture.Effects.ShadowEffect.GetHasShadow(Element).Equals(true))
                    view.AddShadow();
                else
                    view.Layer.ShadowOpacity = 0;
            }
        }
    }
}