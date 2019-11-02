using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.Windows.ViewModels;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class BuildingViewModel : ViewModel<Building>
	{
		private ProductionChainViewModel mProductionChain;

		private int mSortIndex;
		private double mCount;

		public string ProductionBuildingKey => Model?.Key;
		public string ProductionBuildingDisplayName => Model?.DisplayName;

		public ProductionChainViewModel ProductionChain
		{
			get => mProductionChain;
			set
			{
				if (Equals(value, mProductionChain)) return;
				mProductionChain = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ProductionChainDisplayName));
			}
		}

		public string ProductionChainDisplayName => ProductionChain?.DisplayName;

		public double Count
		{
			get => mCount;
			set
			{
				if (value == mCount) return;
				mCount = value;
				OnPropertyChanged();
			}
		}
		public int SortIndex
		{
			get => mSortIndex;
			set
			{
				if (value == mSortIndex) return;
				mSortIndex = value;
				OnPropertyChanged();
			}
		}
	}
}