using System;
using System.Collections.Generic;
using Xamarin.Forms;

using InteractApp;

namespace InteractApp
{
	public partial class CustomEventCell : ViewCell
	{
		public CustomEventCell ()
		{
			InitializeComponent ();

			var EventImage = new Image {
				Aspect = Aspect.AspectFill
			};
			EventImage.SetBinding (Image.SourceProperty, "ImageUri");

			var Indicator = new ActivityIndicator {
				Color = ColorResources.ActivityIndicator,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			Indicator.SetBinding (ActivityIndicator.IsRunningProperty, "IsLoading");
			Indicator.BindingContext = EventImage;

			EventImageGrid.RowDefinitions.Add (new RowDefinition ());

			EventImageGrid.Children.Add (EventImage);
			EventImageGrid.Children.Add (Indicator);
		}
	}
}
