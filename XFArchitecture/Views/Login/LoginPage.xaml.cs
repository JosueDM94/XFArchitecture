using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XFArchitecture.Views.Base;

namespace XFArchitecture.Views.Login
{
    public partial class LoginPage : BasePage
    {
        public LoginPage() : base(nameof(LoginPage))
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}