using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SkiaSharp.Views.Forms;
using System.Runtime.CompilerServices;
using SkiaSharp;
using System.Diagnostics;
using System.Threading.Tasks;

namespace XFArchitecture.Views.User.Register.Indicator
{
    public partial class RegisterIndicator : ContentView
    {
        #region Bindable Properties
        public static readonly BindableProperty PositionProperty = BindableProperty.Create(nameof(Position), typeof(int), typeof(RegisterIndicator), 0, BindingMode.TwoWay);
        public int Position
        {
            get { return (int)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }
        #endregion

        public RegisterIndicator()
        {
            InitializeComponent();
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
        }

        void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            //SKImageInfo info = e.Info;
            //SKSurface surface = e.Surface;
            //SKCanvas canvas = surface.Canvas;
            //float scale = (float)Math.Min(info.Width / CanvasView.Width, info.Height / CanvasView.Height);
            //canvas.Clear();

            //SKPaint paint = new SKPaint()
            //{
            //    Color = ((Color)Application.Current.Resources["Gray500"]).ToSKColor(),
            //    Style = SKPaintStyle.Stroke,
            //    StrokeWidth = 1*scale,
            //    IsAntialias = true
            //};
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            //if (propertyName.Equals(PositionProperty.PropertyName))
        }
    }
}