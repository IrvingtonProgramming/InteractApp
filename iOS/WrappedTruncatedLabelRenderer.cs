using System;

using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using InteractApp;
using InteractApp.iOS;

[assembly: ExportRenderer(typeof(WrappedTruncatedLabel), typeof(WrappedTruncatedLabelRenderer))]
namespace InteractApp.iOS
{
	public class WrappedTruncatedLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.LineBreakMode = UILineBreakMode.TailTruncation;
				Control.Lines = 0;
			}
		}
	}
}

