using System;
using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.Windows.ViewModels;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class ProductionChainComponentViewModel : ViewModel<ProductionChainComponent>
	{
		private ProductionChainComponentListViewModel mOwner;

		private double mCount;
		private int mSortIndex;

		public string ProductionBuildingKey => Model?.Building.Key;
		public string ProductionBuildingDisplayName => Model?.Building.DisplayName;

		public ProductionChainComponentListViewModel Owner
		{
			get => mOwner;
			set
			{
				if (Equals(value, mOwner)) return;
				mOwner = value;
				mCount = Math.Max(1, Model?.Count ?? 1);

				OnPropertyChanged();
				OnPropertyChanged(nameof(Count));
			}
		}
		public override ProductionChainComponent Model
		{
			get => base.Model;
			set
			{
				mCount = Math.Max(1, value?.Count ?? 1);
				base.Model = value;
			}
		}

		public double Count
		{
			get => mCount;
			set
			{
				if (value == mCount) return;
				mCount = value;
				OnPropertyChanged();
				mOwner?.UpdateMultiplicator(this, Model != null && Model.Count > 0 ? mCount / Model.Count : 1);
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

		public double ProductivityRatio => Math.Round(Model?.Ratio * 100 ?? 0);

		public void UpdateMultiplicator(double value)
		{
			mCount = Math.Round(Math.Max(1, Model?.Count ?? 1) * value, 2);
			OnPropertyChanged(nameof(Count));
		}
	}
}