# Interact App

## Description
The new Interact App for District 5170! Members will now be able to view and RSVP to events using their phones.

## Contributing
### Bugs and Feature Requests
Please report any bugs or request any features you find in the issue tracker (issues tab at top), and tag appropriately.
### Bug Fixes or New Features
There are two main branches:  
**master**: production branch; code that is currently deployed to the app store  
**develop**: development branch; latest stable and reviewed code that will go into the next update

All incoming branches should be based off of the latest develop, and all pull requests should go into develop. Please try to conform to the code styles we use (look around in our code for examples). Refer to notes below to set up.

If you want to contribute, please sign up for a student license on [Xamarin](http://www.xamarin.com).

## Notes
### Xamarin
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

### Parse Cloud Code
In `Parse/` run `parse new` after installing the Parse Command Line Tool to initialize the project and start developing.

### Credit
Made by Irvington Programming Club and directed by Vaibhav Aggarwal.
