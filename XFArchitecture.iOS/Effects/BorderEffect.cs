using System;
using System.Linq;
using System.ComponentModel;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using XFArchitecture.iOS.Effects;
using XFArchitecture.iOS.Extensions;

[assembly: ExportEffect(typeof(BorderEffect), nameof(BorderEffect))]
namespace XFArchitecture.iOS.Effects
{
    public class BorderEffect : PlatformEffect
    {
        UIColor borderColor;
        int borderWidth, borderRadius;

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
            if (args.PropertyName.Equals(XFArchitecture.Effects.BorderEffect.BorderColorProperty.PropertyName))
                UpdateBorder();
        }

        private void UpdateBorder()
        {
            borderColor = XFArchitecture.Effects.BorderEffect.GetBorderColor(Element).ToUIColor();
            if (Control != null)
            {
                if (Control is UITextField textField && textField.BorderStyle != UITextBorderStyle.None)
                    textField.BorderStyle = UITextBorderStyle.None;
                Control.AddBorderWithColor(borderRadius, borderColor, borderWidth);
            }                
            else
                Container.AddBorderWithColor(borderRadius, borderColor, borderWidth);
        }
    }
}