using System;
using Okta.Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieExplorer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartupPage : ContentPage
    {
        public StartupPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string token = "";
            try
            {
                // should check for valid login instead
                token = OktaContext.Current.GetToken(TokenKind.AccessToken);
            }
            catch (Exception)
            {

            }
            finally
            {
                // only open Login page when no valid login
                if (string.IsNullOrEmpty(token))
                {
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }
                else
                {
                    await Shell.Current.GoToAsync($"//{nameof(MoviesPage)}");
                }
            }
        }
    }
}