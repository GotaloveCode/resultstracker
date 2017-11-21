using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ResultsTracker
{
    
    public sealed partial class LoginPage : Page, IWebAuthenticationContinuable
    {

        private string _mailAddress;
        private string _displayName = null;
        private MailHelper _mailHelper = new MailHelper();
        private bool _userLoggedIn = false;
        public static ApplicationDataContainer _settings = ApplicationData.Current.LocalSettings;

        public LoginPage()
        {
            this.InitializeComponent();
                    
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Developer code - if you haven't registered the app yet, we warn you. 
            if (!App.Current.Resources.ContainsKey("ida:ClientId"))
            {
                WelcomeText.Text = "Oops - App not registered with Office 365. To run this sample, you must register it with Office 365. You can do that through the 'Add | Connected services' dialog in Visual Studio. See Readme for more info";
                ConnectButton.IsEnabled = false;
            }
            else
            {
                WelcomeText.Text = "Has ID";
                ConnectButton.IsEnabled = true;
            }
        }

        #region IWebAuthenticationContinuable implementation

        // This method is automatically invoked when the application is reactivated after an authentication interaction through WebAuthenticationBroker. 
        // In order to make this method work as expected, you need to create a ContinuationManager object in App.xaml.cs.
        // See http://www.cloudidentity.com/blog/2014/08/28/use-adal-to-connect-your-universal-apps-to-azure-ad-or-adfs/ for
        // more information.
        public async void ContinueWebAuthentication(WebAuthenticationBrokerContinuationEventArgs args)
        {
            var rl = ResourceLoader.GetForCurrentView();
            WelcomeText.Text = "acquiring token...";
            // pass the authentication interaction results to ADAL, which will conclude the token acquisition operation and invoke the callback specified in AcquireTokenAndContinue (in AuthenticationHelper).
            AuthenticationResult result = await AuthenticationHelper._authenticationContext.ContinueAcquireTokenAsync(args);

            if (result.Status == AuthenticationStatus.Success)
            {
                PopulateCurrentUserInformation(result);

            }
            else
            {
                WelcomeText.Text ="AuthenticationErrorMessage";
            }

        }
        #endregion

        //Once we have an AuthenticationResult, get user information.
        private void PopulateCurrentUserInformation(AuthenticationResult result)
        {
            var rl = ResourceLoader.GetForCurrentView();
            AuthenticationHelper._settings.Values["TenantId"] = result.TenantId;
            AuthenticationHelper._settings.Values["LastAuthority"] = AuthenticationHelper._authenticationContext.Authority;

            _displayName = result.UserInfo.GivenName;
            _mailAddress = result.UserInfo.DisplayableId;
            EmailAddressBox.Text = _mailAddress;
            WelcomeText.Text = "Hi " + _displayName + ". " + "WelcomeMessage";
            MailButton.IsEnabled = true;
            EmailAddressBox.IsEnabled = true;
            _userLoggedIn = true;
            ProgressBar.Visibility = Visibility.Collapsed;
            ConnectButton.Content = "disconnect";

        }

        //Button click events.
        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar.Visibility = Visibility.Visible;
            if (_userLoggedIn == false)
            {
                //First try to get an AuthenticationResult silently. This will return with a successful result whenever the user
                //has closed the app without signing out and then relaunched the app.
                AuthenticationResult result = await AuthenticationHelper.AuthenticateSilently();

                //If silent authentication doesn't work, start the browser-based authentication flow.
                if (result != null && result.Status == AuthenticationStatus.Success)
                {
                    PopulateCurrentUserInformation(result);
                }
                else
                {
                    AuthenticationHelper.BeginAuthentication();
                }
            }
            else
            {
                AuthenticationHelper.SignOut();
                WelcomeText.Text = "";
                MailButton.IsEnabled = false;
                EmailAddressBox.IsEnabled = false;
                ConnectButton.Content = "connect";
                this._displayName = null;
                this._mailAddress = null;
                ProgressBar.Visibility = Visibility.Collapsed;
                _userLoggedIn = false;

            }
        }

        private async void MailButton_Click(object sender, RoutedEventArgs e)
        {
            var rl = ResourceLoader.GetForCurrentView();
            WelcomeText.Text = "sending mail...";
            ProgressBar.Visibility = Visibility.Visible;
            _mailAddress = EmailAddressBox.Text;
            try
            {
                await _mailHelper.ComposeAndSendMailAsync("MailSubject", ComposePersonalizedMail(_displayName), _mailAddress);
            }
            catch (Exception)
            {
                WelcomeText.Text = "MailErrorMessage";
            }
            WelcomeText.Text = "mail sent";
            ProgressBar.Visibility = Visibility.Collapsed;
        }

        // <summary>
        // Personalizes the e-mail.
        // </summary>
        public static string ComposePersonalizedMail(string userName)
        {
            var rl = ResourceLoader.GetForCurrentView();
            return String.Format("MailContents", userName);
        }



    }
}
