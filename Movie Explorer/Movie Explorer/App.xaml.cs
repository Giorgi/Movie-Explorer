﻿using Movie_Explorer.Services;
using Movie_Explorer.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movie_Explorer
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<TmdbMovieService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
