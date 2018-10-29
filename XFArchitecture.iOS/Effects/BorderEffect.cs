using System;
using System.Linq;
using System.ComponentModel;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using XFArchitecture.iOS.Effects;
using XFArchitecture.iOS.Extensions;

[assembly: ExportEffect(typeof(BorderEffect), "BorderEffect")]
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
                    borderColor = effect.BorderColor.ToUIColor();
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
        }

        private void UpdateBorder()
        {
            if (Control != null)
            {
                if (Control is UITextField textField)
                    textField.BorderStyle = UITextBorderStyle.None;
                Control.AddBorderWithColor(borderRadius, borderColor, borderWidth);
            }                
            else
                Container.AddBorderWithColor(borderRadius, borderColor, borderWidth);
        }
    }
}