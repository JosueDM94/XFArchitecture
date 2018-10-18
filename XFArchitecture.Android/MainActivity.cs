using Android.OS;
using Android.App;
using Android.Content.PM;

using Xamarin.Forms;
using Acr.UserDialogs;
using Xamarin.Forms.Platform.Android;

using XFArchitecture.Droid.Models;
using XFArchitecture.Core.Services;
using XFArchitecture.Core.Contracts.Dependency;
using XFArchitecture.Droid.Services.Dependency;

namespace XFArchitecture.Droid
{
    [Activity(Label = "XFArchitecture", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);

            UserDialogs.Init(this);
            Forms.Init(this, savedInstanceState);
            AndroidEntity.Init(this, savedInstanceState);

            RegisterDependencies();
            LoadApplication(new App());
        }

        void RegisterDependencies()
        {
            ServiceLocator.Instance.Register<IKeyboardService, KeyboardService>();
        }
    }
}