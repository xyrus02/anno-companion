using System.Diagnostics;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Key}")]
	abstract class IndexedObject
	{
		public string Key { get; set; }
	}
}