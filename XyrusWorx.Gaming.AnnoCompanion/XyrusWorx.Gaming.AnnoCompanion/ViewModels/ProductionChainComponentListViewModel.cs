using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.MVVM;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class ProductionChainComponentListViewModel : CollectionViewModel<ProductionChainComponentViewModel>
	{
		private double mMultiplicator = 1;

		public override IList<ProductionChainComponentViewModel> Items { get; } = new ObservableCollection<ProductionChainComponentViewModel>();

		public double Multiplicator
		{
			get { return mMultiplicator; }
			set
			{
				if (value.Equals(mMultiplicator)) return;
				UpdateMultiplicator(null, value);
			}
		}

		public void Reset(ProductionChain productionChain)
		{
			Items.Clear();
			mMultiplicator = 1;
			OnPropertyChanged(nameof(Multiplicator));

			if (productionChain == null)
			{
				return;
			}

			Items.AddRange(productionChain.Components.Select(x => new ProductionChainComponentViewModel { Owner = this, Model = x }));
		}

		public void UpdateMultiplicator(ProductionChainComponentViewModel sender, double value)
		{
			foreach (var item in Items)
			{
				if (ReferenceEquals(item, sender))
				{
					continue;
				}

				item.UpdateMultiplicator(value);
			}

			mMultiplicator = Math.Round(value, 2);
			OnPropertyChanged(nameof(Multiplicator));
		}
	}
}