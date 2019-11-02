using System.Windows;

namespace XyrusWorx.Gaming.AnnoCompanion.Views
{
	public partial class ProfileSelectionView
	{
		public ProfileSelectionView()
		{
			InitializeComponent();
		}

		private void OnOkClick(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			Close();
		}

		private void OnCancelClick(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
			Close();
		}
	}
}
