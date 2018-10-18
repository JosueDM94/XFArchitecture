using System.Linq;

using Xamarin.Forms;

namespace XFArchitecture.Extensions
{
    public static class AppExtension
    {
        public static Page GetCurrentPage()
        {
            if (Application.Current.MainPage.Navigation.ModalStack.Any())
                return Application.Current.MainPage.Navigation.ModalStack.LastOrDefault();

            return Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
        }

        public static void SaveProperty(string key, object value)
        {
            if (Application.Current.Properties.ContainsKey(key))
                Application.Current.Properties.Remove(key);
            Application.Current.Properties.Add(key, value);
            Application.Current.SavePropertiesAsync();
        }

        public static T GetProperty<T>(string key)
        {
            return (T)Application.Current.Properties[key];
        }
    }
}
