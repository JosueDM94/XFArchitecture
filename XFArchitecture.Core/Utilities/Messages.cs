using System;

namespace XFArchitecture.Core.Utilities
{
    public static class Messages
    {
        #region ErrorMessages
        public const string ErrorTitle = "Error";

        public const string GeneralErrorMessage = "Oops! Something went wrong!";
        public const string ExpiredTokenError = "Sorry, your access token has expired.";

        public const string NoInternetTitleError = "Internet Connection Error";
        public const string NoInternetError = "You must be connected to make this request.";

        public const string UnauthorizedError = "Unauthorized";
        public const string NotAuthenticatedError = "You must be authenticated to make this request.";

        public const string NoGoogleMaps = "Please install google maps to access this feature.";

        public const string NoResultsFoundError = "No results found";
        #endregion

        #region LoadingMessages
        public const string PleaseWait = "Please wait...";
        #endregion

        #region DialogMessages
        public const string Ok = "OK";
        public const string No = "No";
        public const string Yes = "Yes";
        public const string Cancel = "Cancel";
        #endregion
    }
}