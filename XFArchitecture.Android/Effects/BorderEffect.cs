using System;
using System.Linq;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using XFArchitecture.Droid.Effects;
using XFArchitecture.Droid.Extensions;

[assembly: ExportEffect(typeof(BorderEffect), nameof(BorderEffect))]
namespace XFArchitecture.Droid.Effects
{
    public class BorderEffect : PlatformEffect
    {
        int borderWidth, borderRadius;
        Android.Graphics.Color borderColor;

        protected override void OnAttached()
        {
            try
            {
                var effect = (XFArchitecture.Effects.BorderEffect)Element.Effects.FirstOrDefault(e => e is XFArchitecture.Effects.BorderEffect);
                if (effect != null)
                {
                    borderWidth = effect.BorderWidth;
                    borderRadius = effect.BorderRadius;
                    UpdateBorder();
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
            if (args.PropertyName.Equals(XFArchitecture.Effects.BorderEffect.BorderColorProperty))
                UpdateBorder();
        }

        private void UpdateBorder()
        {
            borderColor = XFArchitecture.Effects.BorderEffect.GetBorderColor(Element).ToAndroid();
            if (Control != null)
                Control.AddBorderWithColor(borderRadius, borderColor, borderWidth);
            else
                Container.AddBorderWithColor(borderRadius, borderColor, borderWidth);
        }
    }
}