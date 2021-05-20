using Movie_Explorer.ViewModels;
using Movie_Explorer.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Movie_Explorer
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MovieDetailPage), typeof(MovieDetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
