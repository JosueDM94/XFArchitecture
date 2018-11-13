using System;
using System.ComponentModel;

using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using XFArchitecture.Droid.Effects;

[assembly: ExportEffect(typeof(FontPaddingEffect), nameof(FontPaddingEffect))]
namespace XFArchitecture.Droid.Effects
{
    public class FontPaddingEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                UpdateFontPadding();
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
            if (args.PropertyName.Equals(XFArchitecture.Effects.FontPaddingEffect.IncludeFontPaddingProperty.PropertyName))
                UpdateFontPadding();
        }

        private void UpdateFontPadding()
        {
            if (Control != null && Element != null)
            {
                if (Control is TextView textView)
                    textView.SetIncludeFontPadding(XFArchitecture.Effects.FontPaddingEffect.GetIncludeFontPadding(Element).Value);
            }
        }
    }
}