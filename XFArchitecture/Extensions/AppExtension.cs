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
    }
}
