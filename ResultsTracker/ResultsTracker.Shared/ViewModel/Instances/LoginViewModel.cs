using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Globalization;
using System.Net.Http;

namespace ResultsTracker
{

    public class LoginViewModel
    {
        #region Config Values

        //
        // The Client ID is used by the application to uniquely identify itself to Azure AD.
        // The Tenant is the name of the Azure AD tenant in which this application is registered.
        // The AAD Instance is the instance of Azure, for example public Azure or Azure China.
        // The Authority is the sign-in URL of the tenant.
        //

        const string aadInstance = "https://login.microsoftonline.com/{0}";
        const string tenant = "masterpiecenet.co.ke";
        const string clientId = "932a8dca-52cc-4002-8785-6b8a0b5ef183";

        static string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        const string graphResourceId = "https://graph.windows.net/";
        const string graphEndpoint = "https://graph.windows.net/";
        const string graphApiVersion = "1.5";

        #endregion

        private HttpClient httpClient = new HttpClient();
        private AuthenticationContext authContext = null;
        private Uri redirectURI = null;

        public LoginViewModel()
        {
            redirectURI = Windows.Security.Authentication.Web.WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
            //ms-app://s-1-15-2-1510460879-286437977-2774768364-772860701-2520001954-3828318141-1300680690/
        }
    }
}
