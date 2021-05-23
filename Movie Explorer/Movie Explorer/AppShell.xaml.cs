using System;
using MovieExplorer.ViewModels;
using MovieExplorer.Views;
using Okta.Xamarin;
using Xamarin.Forms;

namespace MovieExplorer
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MovieDetailPage), typeof(MovieDetailPage));
            BindingContext = new ShellViewModel();
        }

        public UserInfo User
        {
            get => (BindingContext as ShellViewModel).User;
            set
            {
                (BindingContext as ShellViewModel).User = value;
            }
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await OktaContext.Current.SignOutAsync();
        }
    }
}
