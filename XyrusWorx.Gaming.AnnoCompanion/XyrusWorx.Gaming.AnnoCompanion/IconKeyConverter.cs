using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace XyrusWorx.Gaming.AnnoCompanion
{
	class IconKeyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var key = value as string;
			var group = parameter as string;

			if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(group))
			{
				return null;
			}

			try
			{
				return new ImageSourceConverter().ConvertFromString($"pack://application:,,,/Resources/Icons/{group}/{key}.png");
			}
			catch
			{
				return null;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
