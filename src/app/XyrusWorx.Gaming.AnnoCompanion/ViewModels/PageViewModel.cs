using XyrusWorx.Windows.ViewModels;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	abstract class PageViewModel : ViewModel
	{
		public abstract string Header { get; }

		public abstract int SortIndex { get; }

		public virtual void Load() { }
	}
}