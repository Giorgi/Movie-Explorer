using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Okta.Xamarin;
using Okta.Xamarin.Android;
using Xamarin.Forms;

namespace Movie_Explorer.Droid
{
    [Activity(Label = "Movie_Explorer", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : OktaMainActivity<App>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override async void OnSignInCompleted(object sender, SignInEventArgs signInEventArgs)
        {
            await Shell.Current.GoToAsync("//MoviesPage", true);
            var user = await OktaContext.Current.GetUserAsync<UserInfo>();
            ((AppShell) Shell.Current).User = user;
        }

        public override void OnSignOutCompleted(object sender, SignOutEventArgs signOutEventArgs)
        {
            Shell.Current.GoToAsync("//LoginPage", true);
        }
    }
}