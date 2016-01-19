﻿using System;
using System.Collections;

using Xamarin.Forms;

namespace InteractApp
{
	public class BindablePicker : Picker
	{
		public BindablePicker ()
		{
			this.SelectedIndexChanged += OnSelectedIndexChanged;
		}

		public static BindableProperty ItemsSourceProperty =
			BindableProperty.Create<BindablePicker, IList> (o => o.ItemsSource, default(IList), propertyChanged: OnItemsSourceChanged);

		public static BindableProperty SelectedItemProperty =
			BindableProperty.Create<BindablePicker, object> (o => o.SelectedItem, default(object));


		public string DisplayMember { get; set; }

		public IList ItemsSource {
			get { return (IList)GetValue (ItemsSourceProperty); }
			set { SetValue (ItemsSourceProperty, value); }
		}

		public object SelectedItem {
			get { return (object)GetValue (SelectedItemProperty); }
			set { 
				SetValue (SelectedItemProperty, value);
				UpdateSelected ();
			}
		}

		private void UpdateSelected ()
		{
			if (ItemsSource != null) {
				if (ItemsSource.Contains (SelectedItem)) {
					SelectedIndex = ItemsSource.IndexOf (SelectedItem);
				} else {
					SelectedIndex = -1;
				}
			}
		}

		private static void OnItemsSourceChanged (BindableObject bindable, IList oldvalue, IList newvalue)
		{
			var picker = bindable as BindablePicker;

			if (picker != null) {
				picker.Items.Clear ();
				if (newvalue == null)
					return;
				//now it works like "subscribe once" but you can improve
				foreach (var item in newvalue) {
					if (string.IsNullOrEmpty (picker.DisplayMember)) {
						picker.Items.Add (item.ToString ());
					} else {
						var type = item.GetType ();

						var prop = type.GetProperty (picker.DisplayMember);


						//var value = 
						picker.Items.Add (prop.GetValue (item).ToString ());
					}
				}
				picker.UpdateSelected ();
			}
		}

		private void OnSelectedIndexChanged (object sender, EventArgs eventArgs)
		{
			if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1) {
				SelectedItem = null;
			} else {
				SelectedItem = ItemsSource [SelectedIndex];
			}
		}
	}
}
