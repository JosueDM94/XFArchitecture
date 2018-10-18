using Android.OS;
using Android.App;
using Android.Content;

namespace XFArchitecture.Droid.Models
{
    public static class AndroidEntity
    {
        public static Bundle Bundle { get; set; }
        public static Context Context { get; set; }
        public static Activity Activity { get; set; }

        public static void Init(Activity activity, Bundle bundle)
        {
            Bundle = bundle;
            Context = activity;
            Activity = activity;
        }
    }
}
