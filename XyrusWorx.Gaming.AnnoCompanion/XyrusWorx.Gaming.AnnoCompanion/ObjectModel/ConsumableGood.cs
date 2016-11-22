namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class ConsumableGood : Good
	{
		private ProvisionCapacity[] mProvisionCapacities;

		public ProvisionCapacity[] ProvisionCapacities
		{
			get { return mProvisionCapacities ?? new ProvisionCapacity[0]; }
			set { mProvisionCapacities = value; }
		}
	}
}