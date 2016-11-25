using System;
using System.Globalization;
using System.Windows.Data;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.Runtime;

namespace XyrusWorx.Gaming.AnnoCompanion.Components
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
				var provider = ServiceLocator.Default.Resolve<IIconResolverFactory>().GetIconResolver();

				return provider.GetIcon(key, group);
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
