﻿using System.Linq;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;
using XyrusWorx.MVVM;
using XyrusWorx.Windows.ViewModels;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class ProductionChainViewModel : ViewModel<ProductionChain>, IHideable
	{
		public ProductionChainViewModel()
		{
			Components = new ProductionChainComponentListViewModel();
		}
		public ProductionChainViewModel(ProductionChainComponentListViewModel components) : this()
		{
			Components = components;
		}

		public string DisplayName => Model?
			.OutputGood?
			.DisplayName;

		public string PrincipalPopulationGroup => Model?
			.OutputGood?
			.CastTo<ConsumableGood>()?
			.ConsumingPopulationGroups?
			.OrderBy(x => x.Tier)
			.FirstOrDefault(x => x.Tier > 0)?
			.Key;

		public Good OutputGood => Model?.OutputGood;

		public bool IsVisible { get; set; }

		public ProductionChainComponentListViewModel Components { get; }

		public override ProductionChain Model
		{
			get { return base.Model; }
			set
			{
				base.Model = value;
				Components?.Reset(value);
			}
		}
	}
}