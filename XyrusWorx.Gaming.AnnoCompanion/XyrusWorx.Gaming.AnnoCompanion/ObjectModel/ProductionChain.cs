namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class ProductionChain
	{
		public ConsumableGood OutputGood { get; set; }

		public ProductionChainComponent[] Components { get; set; }

		public ProvisionCapacity[] ProvisionCapacities { get; set; }
	}
}