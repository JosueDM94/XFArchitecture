using System;

namespace XFArchitecture.Core.Utilities
{
    public static class Constants
    {
        #region App
        public const string AppId = "com.itexico.xfarchitecture";
        public const string AppName = "XFArchitecture";
        public const string AppVersion = "1.0.0";

        public static string DeviceOS = "";
        public const string DatabaseName = "XFArchitecture.db3";
        #endregion

        #region MapAPiKey
        public const string DroidMapKey = "";
        public const string iOSMapKey = "";
        #endregion

        #region PushNotification
        public const string GlobalChannel = "";
        #endregion

        #region OAUTH
        public static string Token = "";
        public static string FirebaseToken = "";
        #endregion

        #region HttpClient
        public const int MaxResponseContentBufferSize = 256000;
        #endregion

        #region WS URI
        public static Uri BASE_URI = new Uri("https://www.google.com");
        public static string DEBUG_BASE_URI = "";
        public static string PRODUCTION_BASE_URI = "";
        #endregion

        #region Analytics Events Strings
        public const string ScreenAnalytics = "Screen {0} - {1}";
        #endregion

        #region Images
        #endregion
    }
}