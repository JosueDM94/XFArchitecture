using Xamarin.Forms;

namespace XFArchitecture.Effects
{
    public class BorderEffect : RoutingEffect
    {
        #region Bindables Properties
        public int BorderWidth { get; set; } = 0;

        public int BorderRadius { get; set; } = 0;

        public Color BorderColor { get; set; } = Color.Default;
        #endregion

        public BorderEffect() : base("com.itexico.XFArchitecture.BorderEffect")
        {
        }
    }
}