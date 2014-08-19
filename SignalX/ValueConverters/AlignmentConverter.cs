using System;
using Xamarin.Forms;
using System.Globalization;

namespace SignalX
{
	public class AlignmentConverter : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			var isLocalUser = (bool)value;
			return TextAlignment.End;
			//return value;
		}

		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}