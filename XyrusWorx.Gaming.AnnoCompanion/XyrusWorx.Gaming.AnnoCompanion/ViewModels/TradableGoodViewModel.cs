using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.MVVM;
using XyrusWorx.Windows.ViewModels;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class TradableGoodViewModel : ViewModel<Good>, IHideable
	{
		private int mCount;
		private TradableGoodListViewModel mOwner;

		public TradableGoodListViewModel Owner
		{
			get { return mOwner; }
			set
			{
				if (Equals(value, mOwner)) return;
				mOwner = value;
				OnPropertyChanged();
			}
		}

		public int Count
		{
			get { return mCount; }
			set
			{
				if (value == mCount) return;
				mCount = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(TradeValue));
				OnPropertyChanged(nameof(ProductionCost));
				OnPropertyChanged(nameof(Profit));
				OnPropertyChanged(nameof(IsProfitable));

				Owner?.UpdateValues();
			}
		}

		public string Key => Model?.Key;
		public string DisplayName => Model?.DisplayName;
		public double TradeValue => UnitTradeValue * mCount;
		public double ProductionCost => UnitProductionCost * mCount;
		public double Profit => TradeValue - ProductionCost;

		public double UnitTradeValue => Model?.TradeValue ?? 0;
		public double UnitProductionCost => Model?.ProductionCost ?? 0;
		public double UnitProfit => UnitTradeValue - UnitProductionCost;

		public bool IsProfitable => Profit >= 0;
		public bool IsVisible { get; set; }
	}
}