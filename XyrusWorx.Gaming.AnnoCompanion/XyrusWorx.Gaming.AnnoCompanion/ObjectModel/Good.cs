using System.Diagnostics;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Key}")]
	abstract class Good : IndexedObject
	{
		public string DisplayName { get; set; }

		public PopulationRequirement UnlockThreshold { get; set; }
	}
}