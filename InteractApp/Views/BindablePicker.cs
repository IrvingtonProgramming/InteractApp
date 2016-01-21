using System;
using System.Collections;

using Xamarin.Forms;
using System.Collections.Specialized;

namespace InteractApp
{
	public class BindablePicker : Picker
	{
		public BindablePicker ()
		{
			this.SelectedIndexChanged += OnSelectedIndexChanged;
		}

		public static BindableProperty ItemsSourceProperty =
			BindableProperty.Create<BindablePicker, IEnumerable> (o => o.ItemsSource, default(IEnumerable), propertyChanged: OnItemsSourceChanged);

		public static BindableProperty SelectedItemProperty =
			BindableProperty.Create<BindablePicker, object> (o => o.SelectedItem, default(object));


		public string DisplayMember { get; set; }

		public IEnumerable ItemsSource {
			get { return (IEnumerable)GetValue (ItemsSourceProperty); }
			set { SetValue (ItemsSourceProperty, value); }
		}

		public object SelectedItem {
			get { return (object)GetValue (SelectedItemProperty); }
			set { SetValue (SelectedItemProperty, value); }
		}

		private static void OnItemsSourceChanged (BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
		{
			var picker = bindable as BindablePicker;

			if (picker != null) {
				picker.Items.Clear ();
				if (newvalue == null)
					return;
				foreach (var item in newvalue) {
					if (string.IsNullOrEmpty (picker.DisplayMember)) {
						picker.Items.Add (item.ToString ());
					} else {
						var type = item.GetType ();

						var prop = type.GetProperty (picker.DisplayMember);

						picker.Items.Add (prop.GetValue (item).ToString ());
					}
				}
			}
		}

		private void OnSelectedIndexChanged (object sender, EventArgs eventArgs)
		{
			if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1) {
				SelectedItem = null;
			} else {
				SelectedItem = Items [SelectedIndex];
			}
		}

		private static void OnSelectedItemChanged (BindableObject bindable, object oldvalue, object newvalue)
		{
			var picker = bindable as BindablePicker;
			if (newvalue != null) {
				picker.SelectedIndex = picker.Items.IndexOf (newvalue.ToString ());
			}
		}
	}
}

