using Okta.Xamarin;

namespace MovieExplorer.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private UserInfo user;

        public UserInfo User
        {
            get => user;
            set
            {
                SetProperty(ref user, value);
            }
        }
    }
}