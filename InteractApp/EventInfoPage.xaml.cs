using Xamarin.Forms;
using Android.Support.Design.Widget;
using Java.Security.Cert;

namespace InteractApp
{
	public partial class EventInfoPage : ContentPage
	{
		private static bool _subscribed = false;

		readonly EventInfoPageViewModel _viewModel;

		public EventInfoPageViewModel ViewModel {
			get {
				return _viewModel;
			}
		}

		public EventInfoPage (Event evt)
		{
			InitializeComponent ();

			_viewModel = new EventInfoPageViewModel (evt);
			BindingContext = _viewModel;

			ToolbarItems.Add (new ToolbarItem {
				Text = "RSVP",
				Order = ToolbarItemOrder.Primary,
				Command = new Command (ViewModel.RSVP),
			});

			if (!_subscribed) {
				MessagingCenter.Subscribe<EventInfoPageViewModel> (this, "Invalid URI", (sender) => {
					DisplayAlert ("Oops", "Invalid URI. Either you can't RSVP to this, or we screwed up. If you believe we screwed up, please contact Interact.", "YESSIR");
				});
				_subscribed = true;
			}
		}
	}
}
