# Interact App

## Description
The new Interact App for District 5170! Members will now be able to view and RSVP to events using their phones.

## Notes
###Xamarin
API Keys should be stored in `InteractApp/Constants.cs` like this:
```
using System;

namespace InteractApp
{
	public class Constants
	{
		// https://www.parse.com/apps/interactapp--2/edit#settings

		// APPLICATION ID
		public static readonly string ApplicationId = "app id here";
		// .NET KEY
		public static readonly string Key = ".net key here";
	}
}
```

###Parse Cloud Code
In `Parse/` run `parse new` after installing the Parse Command Line Tool to initialize the project and start developing.

###Credit
Made by Irvington Programming Club and directed by Vaibhav Aggarwal and Kevin Prakash.
