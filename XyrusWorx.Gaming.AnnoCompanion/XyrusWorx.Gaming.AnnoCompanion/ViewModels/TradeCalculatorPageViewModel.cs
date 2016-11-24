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
		public TradeCalculatorPageViewModel()
		{
			ResetAllCommand = new RelayCommand(ResetAll);
		}
		public TradeCalculatorPageViewModel(TradableGoodListViewModel tradeGoodList, IDataProvider dataProvider) : this()
		{
			TradeGoods = tradeGoodList;
			TradeGoods?.Items.Reset(
				from good in dataProvider?.GetAll<Good>() ?? new Good[0]
				orderby good.TradeValue - good.ProductionCost descending 
				select new TradableGoodViewModel
				{
					Model = good,
					Owner = TradeGoods
				});
		}

		public ICommand ResetAllCommand { get; }
		public void ResetAll()
		{
			TradeGoods?.Items.Foreach(x => x.Count = 0);
		}

		public override string Header => "Handelsrechner";
		public override int SortIndex => 3;
		
		public TradableGoodListViewModel TradeGoods { get; }
	}
}