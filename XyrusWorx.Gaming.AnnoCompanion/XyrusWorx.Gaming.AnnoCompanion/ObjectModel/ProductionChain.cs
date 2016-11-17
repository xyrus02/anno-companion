using System.Diagnostics;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{OutputGood}")]
	class ProductionChain : IndexedObject
	{
		public Good OutputGood { get; set; }

		public ProductionChainComponent[] Components { get; set; }

		public ProvisionCapacity[] ProvisionCapacities { get; set; }
	}
}