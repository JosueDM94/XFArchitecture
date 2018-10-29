using Xamarin.Forms;

using XFArchitecture.Core.Contracts.General;

namespace XFArchitecture.Services.General
{
    public class ApplicationService : IApplicationService
    {
        public void SaveProperty(string key, object value)
        {
            if (Application.Current.Properties.ContainsKey(key))
                Application.Current.Properties.Remove(key);
            Application.Current.Properties.Add(key, value);
            Application.Current.SavePropertiesAsync();
        }

        public T GetProperty<T>(string key)
        {
            return (T)Application.Current.Properties[key];
        }
    }
}