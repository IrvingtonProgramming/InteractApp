using System;
using Xamarin.Forms;
using System.Collections;
using System.Globalization;

namespace InteractApp
{
	public class DataSourceConverter: IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value != null ? ((IList)value).Count == 0 : false;
		}

		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}

