﻿using Android.OS;
using Android.App;
using Android.Content.PM;

using Xamarin.Forms;
using Acr.UserDialogs;
using Lottie.Forms.Droid;
using FFImageLoading.Forms.Platform;
using Xamarin.Forms.Platform.Android;

using XFArchitecture.Droid.Models;
using XFArchitecture.Core.Services;
using XFArchitecture.Core.Contracts.Dependency;
using XFArchitecture.Droid.Services.Dependency;

[assembly: ResolutionGroupName("com.itexico.XFArchitecture")]
namespace XFArchitecture.Droid
{
    [Activity(Label = "MainActivity", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);

            Forms.SetFlags("CollectionView_Experimental");
            Forms.Init(this, savedInstanceState);
            UserDialogs.Init(this);
            AnimationViewRenderer.Init();
            CachedImageRenderer.Init(false);
            AndroidEntity.Init(this, savedInstanceState);
            CarouselView.FormsPlugin.Android.CarouselViewRenderer.Init();

            RegisterDependencies();
            LoadApplication(new App());
        }

        void RegisterDependencies()
        {
            ServiceLocator.Instance.Register<KeyboardService, IKeyboardService>();
        }
    }
}