using System;
using System.Globalization;
using System.Windows.Data;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;
using XyrusWorx.Runtime;

namespace XyrusWorx.Gaming.AnnoCompanion.Components
{
	class PopulationGroupConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var key = value as string;
			var repository = ServiceLocator.Default.Resolve<IDataProvider>();

			return repository.Get<PopulationGroup>(key);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}