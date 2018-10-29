using Android.OS;
using Android.App;
using Android.Content;
using Android.Content.PM;

namespace XFArchitecture.Droid.Views.Splash
{
    [Activity(Label = "XFArchitecture", Icon = "@mipmap/icon", Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (!IsTaskRoot)
            {
                Finish();
                return;
            }
            using (var intent = new Intent(this, typeof(MainActivity)))
                StartActivity(intent);
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }
    }
}