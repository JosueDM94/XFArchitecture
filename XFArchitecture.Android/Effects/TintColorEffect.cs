using System;
using System.Linq;
using System.ComponentModel;

using Android.Widget;
using Android.Graphics;

using XFArchitecture.Droid.Effects;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(TintColorEffect), nameof(TintColorEffect))]
namespace XFArchitecture.Droid.Effects
{
    public class TintColorEffect : PlatformEffect
    {
        Android.Graphics.Color tintColor;
        
        protected override void OnAttached()
        {
            try
            {
                var effect = (XFArchitecture.Effects.TintColorEffect)Element.Effects.FirstOrDefault(e => e is XFArchitecture.Effects.TintColorEffect);
                if (effect != null)
                {
                    tintColor = effect.TintColor.ToAndroid();

                    ApplyTintColor();
                }
            }
            catch (Exception ex)
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
        }

        private void ApplyTintColor()
        {
            var colorFilter = new PorterDuffColorFilter(tintColor, PorterDuff.Mode.SrcIn);
            if(Control is ImageView)
            {
                (Control as ImageView).ClearColorFilter();                
                (Control as ImageView).SetColorFilter(colorFilter);
            }
            else
            {
                Control.Background.ClearColorFilter();                
                Control.Background.SetColorFilter(colorFilter);
            }
        }
    }
}