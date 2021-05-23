using Android.App;
using Android.Content;
using Android.Content.PM;
using Okta.Xamarin.Android;

namespace Movie_Explorer.Droid
{
    [Activity(Label = "LogoutCallbackInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleInstance)]
    [IntentFilter(actions: new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, DataSchemes = new[] { "com.okta.dev-7462271.logout" }, DataPath = "/callback")]
    public class LogoutCallbackInterceptorActivity : OktaLogoutCallbackInterceptorActivity<MainActivity>
    {
    }
}