using Android.App;
using Android.Content.PM;
using Android.Content;
using Okta.Xamarin.Android;

namespace Movie_Explorer.Droid
{
    [Activity(Label = "LoginCallbackInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleInstance)]
    [IntentFilter(actions: new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, DataSchemes = new[] { "com.okta.dev-7462271" }, DataPath = "/callback")]
    public class LoginCallbackInterceptorActivity : OktaLoginCallbackInterceptorActivity<MainActivity>
    {
    }
}