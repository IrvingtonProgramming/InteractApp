using System;

using Xamarin.Forms;

namespace InteractApp
{
	public static class ColorResources
	{
		public static readonly Color ActivityIndicator = Device.OnPlatform (Color.Default, Color.Default, Color.Default);
		public static readonly Color InteractColor = Color.FromHex ("#01B4E7");
	}
}

