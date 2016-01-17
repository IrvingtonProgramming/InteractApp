using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InteractApp
{
	public partial class MyInfoPage : ContentPage
	{
		public static readonly int[] AREA_CHOICES = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
		public static readonly int[] GRADE_CHOICES = { 9, 10, 11, 12 };

		public MyInfoPage ()
		{
			InitializeComponent ();
			this.Title = "My Info";



			MyInfoGrade.Items.Clear ();
			foreach (int g in GRADE_CHOICES) {
				MyInfoGrade.Items.Add (g.ToString ());
			}
		}
	}
}

