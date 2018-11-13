using System;
using CoreGraphics;
using UIKit;

namespace XFArchitecture.iOS.Extensions
{
    public static class ControllerExtension
    {
        public static UIView AddBorderWithColor(this UIView vw, nfloat radius, UIColor borderColor, int width = 0, UIColor backgroundColor = null)
        {
            vw.Layer.BorderWidth = width == 0 ? 2 : width;
            vw.Layer.BorderColor = borderColor.CGColor;
            vw.Layer.CornerRadius = radius;

            if (backgroundColor != null)
                vw.BackgroundColor = backgroundColor;

            return vw;
        }

        public static UIView AddShadow(this UIView vw)
        {
            vw.Layer.ShadowRadius = 1f;
            vw.Layer.ShadowOpacity = 0.30f;
            vw.Layer.ShadowOffset = new CGSize(0, 2);
            vw.Layer.ShadowColor = UIColor.Black.CGColor;
            return vw;
        }
    }
}