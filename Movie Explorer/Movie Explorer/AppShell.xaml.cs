using Movie_Explorer.ViewModels;
using Movie_Explorer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Okta.Xamarin;
using Xamarin.Forms;

namespace Movie_Explorer
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
            //await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
