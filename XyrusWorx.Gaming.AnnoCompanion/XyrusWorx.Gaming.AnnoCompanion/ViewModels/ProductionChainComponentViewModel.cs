using System;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;
using XyrusWorx.MVVM;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class ProductionChainComponentViewModel : ViewModel<ProductionChainComponent>
	{
		private ProductionChainComponentListViewModel mOwner;
		private ProductionChainViewModel mProductionChain;

		private double mCount;
		private int mSortIndex;

		public string ProductionBuildingKey => Model?.Building?.Key;
		public string ProductionBuildingDisplayName => Model?.Building?.DisplayName;

		public ProductionChainComponentListViewModel Owner
		{
			get { return mOwner; }
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
			get { return base.Model; }
			set
			{
				mCount = Math.Max(1, value?.Count ?? 1);
				base.Model = value;
			}
		}
		public ProductionChainViewModel ProductionChain
		{
			get { return mProductionChain; }
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
			get { return mCount; }
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
			get { return mSortIndex; }
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