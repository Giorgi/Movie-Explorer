using Movie_Explorer.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Okta.Xamarin;
using Xamarin.Forms;

namespace Movie_Explorer.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await OktaContext.Current.SignInAsync();
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
