using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using InteractApp;
using InteractApp.Droid;

[assembly: ExportRenderer(typeof(WrappedTruncatedLabel), typeof(WrappedTruncatedLabelRenderer))]
namespace InteractApp.Droid
{
	public class WrappedTruncatedLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.LayoutChange += (s, args) =>
				{
					Control.Ellipsize = Android.Text.TextUtils.TruncateAt.End;
					Control.SetMaxLines((int)((args.Bottom - args.Top) / Control.LineHeight));
				};
			}
		}
	}
}

