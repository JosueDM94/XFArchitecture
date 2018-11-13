using Android.Views;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace XFArchitecture.Droid.Extensions
{
    public static class ActivityExtension
    {
        public static View AddBorderWithColor(this View vw, float radius, Color borderColor, int width = 0, Color? backgroundColor = null)
        {
            var border = new GradientDrawable();
            var vwBackground = (vw.Background as ColorDrawable);
            border.SetStroke(width == 0 ? 2 : width, borderColor);
            border.SetCornerRadius(radius * vw.Context.Resources.DisplayMetrics.Density);
            border.SetColor(backgroundColor != null ? backgroundColor.Value : vwBackground != null ? vwBackground.Color:Color.Transparent);
            vw.Background = border;
            return vw;
        }
    }
}