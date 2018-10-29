using System;
using System.Linq;
using System.ComponentModel;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using XFArchitecture.iOS.Effects;

[assembly: ExportEffect(typeof(TintColorEffect), nameof(TintColorEffect))]
namespace XFArchitecture.iOS.Effects
{   
    public class TintColorEffect : PlatformEffect
    {       
        UIColor tintColor;
        
        protected override void OnAttached()
        {
            try
            {
                var effect = (XFArchitecture.Effects.TintColorEffect)Element.Effects.FirstOrDefault(e => e is XFArchitecture.Effects.TintColorEffect);
                if (effect != null)
                {                    
                    tintColor = effect.TintColor.ToUIColor();

                    ClearTintColor();
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
            ClearTintColor();
            ApplyTintColor();
        }

        private void ClearTintColor()
        {
            if (Control is UIImageView)
                (Control as UIImageView).Image = (Control as UIImageView).Image?.ImageWithRenderingMode(UIImageRenderingMode.Automatic);
            Control.TintColor = null;
        }

        private void ApplyTintColor()
        {
            if (Control is UIImageView)
                (Control as UIImageView).Image = (Control as UIImageView).Image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            Control.TintColor = tintColor;
        }
    }
}