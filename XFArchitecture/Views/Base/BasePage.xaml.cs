using System;

using Xamarin.Forms;
using Xamarin.Essentials;

using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;

using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Views.Base
{
    public partial class BasePage : ContentPage
    {
        private string ScreenName { get; set; }

        public BasePage(string screenName)
        {
            try
            {
                InitializeComponent();
                ScreenName = screenName;
                Constants.DeviceOS = DeviceInfo.Platform.ToString();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Analytics.TrackEvent(string.Format(Constants.ScreenAnalytics, Constants.DeviceOS, ScreenName));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
