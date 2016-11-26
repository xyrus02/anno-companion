using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.Windows.Input;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class TradeCalculatorPageViewModel : PageViewModel
	{
		private readonly IDataProvider mDataProvider;
		private int mSort;

		public TradeCalculatorPageViewModel()
		{
			ResetAllCommand = new RelayCommand(ResetAll);
		}
		public TradeCalculatorPageViewModel(TradableGoodListViewModel tradeGoodList, IDataProvider dataProvider) : this()
		{
			mDataProvider = dataProvider;
			TradeGoods = tradeGoodList;
			TradeGoods?.Items.Reset(
				from good in mDataProvider?.GetAll<Good>() ?? new Good[0]
				orderby good.TradeValue - good.ProductionCost descending
				select new TradableGoodViewModel
				{
					Model = good,
					Owner = TradeGoods,
					IsVisible = true
				});
		}

		public ICommand ResetAllCommand { get; }
		public void ResetAll()
		{
			TradeGoods?.Items.Foreach(x => x.Count = 0);
		}

		public override string Header => "Handelsrechner";
		public override int SortIndex => 3;

		public bool SortByTradeValue
		{
			get { return mSort == 0; }
			set
			{
				if (value && mSort == 0) return;
				if (value)
				{
					mSort = 0;
					OnPropertyChanged();
					OnPropertyChanged(nameof(SortByDisplayName));

					TradeGoods.Items.Reset(new List<TradableGoodViewModel>(
						from element in TradeGoods.Items
						orderby element.TradeValue - element.ProductionCost descending
						select element));
				}
			}
		}
		public bool SortByDisplayName
		{
			get { return mSort == 1; }
			set
			{
				if (value && mSort == 1) return;
				if (value)
				{
					mSort = 1;
					OnPropertyChanged();
					OnPropertyChanged(nameof(SortByTradeValue));

					TradeGoods.Items.Reset(new List<TradableGoodViewModel>(
						from element in TradeGoods.Items
						orderby element.DisplayName ascending
						select element));
				}
			}
		}

		public TradableGoodListViewModel TradeGoods { get; }
	}
}