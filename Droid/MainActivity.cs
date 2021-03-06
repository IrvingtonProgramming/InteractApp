﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace InteractApp.Droid
{
	[Activity (Label = "Interact 5170", Icon = "@drawable/ic_launcher", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
	{
		EventManager eventManager;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;

			eventManager = new EventManager (ParseStorage.Default);

			App.SetEventManager (eventManager);

			LoadApplication (new App ());
		}
	}
}
