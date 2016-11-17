using System.Diagnostics;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Building}")]
	class ProductionChainComponent
	{
		public ProductionChainComponent()
		{
		}
		public ProductionChainComponent(int count, Building building, double ratio = 1.0) : this()
		{
			Count = count;
			Building = building;
			Ratio = ratio;
		}

		public int Count { get; set; }

		public double Ratio { get; set; }

		public Building Building { get; set; }
	}
}