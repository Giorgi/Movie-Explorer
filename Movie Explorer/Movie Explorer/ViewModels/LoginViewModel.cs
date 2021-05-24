using Okta.Xamarin;
using Xamarin.Forms;

namespace MovieExplorer.ViewModels
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
        }
    }
}
