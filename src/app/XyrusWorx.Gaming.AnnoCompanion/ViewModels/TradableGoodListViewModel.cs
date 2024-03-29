﻿using System;
using System.Linq;
using System.Threading.Tasks;
using XyrusWorx.Windows.ViewModels;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class TradableGoodListViewModel : SearchableCollectionViewModel<TradableGoodViewModel>
	{
		private double mTradeValueSum;
		private double mProductionCostSum;
		private double mProfitSum;

		public TradableGoodListViewModel()
		{
			AutomaticallyUpdateSearchResults = true;
			InputDelay = TimeSpan.FromMilliseconds(500);
		}

		protected override bool IsVisible(TradableGoodViewModel element)
		{
			return Expression.IsMatch(element.DisplayName);
		}

		public double TradeValueSum
		{
			get => mTradeValueSum;
			private set
			{
				if (value.Equals(mTradeValueSum)) return;
				mTradeValueSum = value;
				OnPropertyChanged();
			}
		}

		public double ProductionCostSum
		{
			get => mProductionCostSum;
			private set
			{
				if (value.Equals(mProductionCostSum)) return;
				mProductionCostSum = value;
				OnPropertyChanged();
			}
		}

		public double ProfitSum
		{
			get => mProfitSum;
			set
			{
				if (value.Equals(mProfitSum)) return;
				mProfitSum = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(IsProfitable));
			}
		}

		public bool IsProfitable => ProfitSum >= 0;

		public void UpdateValues()
		{
			TradeValueSum = Items.Sum(x => x.TradeValue);
			ProductionCostSum = Items.Sum(x => x.ProductionCost);
			ProfitSum = Items.Sum(x => x.Profit);
		}
	}
}