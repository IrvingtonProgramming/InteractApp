using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Content.PM;

namespace InteractApp.Droid
{
	[Activity (Label = "Interact 5170", MainLauncher = true, Icon = "@drawable/ic_launcher", NoHistory = true, Theme = "@style/Theme.Splash", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class SplashScreen : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			StartActivity (typeof(MainActivity));
		}
	}
}
