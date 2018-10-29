using Xamarin.Forms;

namespace XFArchitecture.Effects
{
    public class TintColorEffect : RoutingEffect
    {             
        #region Bindables Properties
        public Color TintColor { get; set; }
        #endregion

        public TintColorEffect() : base("com.itexico.XFArchitecture.TintColorEffect")
        {
        }
    }
}