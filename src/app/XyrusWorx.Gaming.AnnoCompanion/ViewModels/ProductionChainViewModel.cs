﻿using System.Linq;
using XyrusWorx.Gaming.AnnoCompanion.Models;
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
			.ProvisionCapacities
			.Select(x => x.PopulationGroup)
			.OrderBy(x => x.Tier)
			.FirstOrDefault()?
			.Key;

		public int SortIndex =>
			10000 * (Model?.OutputGood?.CastTo<ConsumableGood>() == null ? 1 : 2) +
			1000 * (Model?.OutputBuilding?.UnlockThreshold.PopulationGroup.Fraction.SortOrder ?? 0) +
			100 * (Model?.OutputBuilding?.UnlockThreshold.PopulationGroup.Tier ?? 1) +
			10 * (Model?.OutputBuilding?.UnlockThreshold.Count ?? 0);

		public Good OutputGood => Model?.OutputGood;

		public bool IsVisible { get; set; }

		public ProductionChainComponentListViewModel Components { get; }

		public override ProductionChain Model
		{
			get => base.Model;
			set
			{
				base.Model = value;
				Components?.Reset(value);
			}
		}

		public int Count
		{
			get => (int)Components.Multiplicator;
			set
			{
				if (value == Count) return;
				Components.Multiplicator = value;
				OnPropertyChanged();
			}
		}
	}
}