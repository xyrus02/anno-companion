using System;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;
using XyrusWorx.MVVM;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class ProductionChainComponentViewModel : ViewModel<ProductionChainComponent>
	{
		private ProductionChainComponentListViewModel mOwner;
		private double mCount;

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

		public void UpdateMultiplicator(double value)
		{
			mCount = Math.Round(Math.Max(1, Model?.Count ?? 1) * value, 2);
			OnPropertyChanged(nameof(Count));
		}
	}
}