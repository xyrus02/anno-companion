using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.MVVM;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class PopulationGroupViewModel : ViewModel<PopulationGroup>
	{
		private int mCount;
		private int mTurnaroundThreshold;

		public PopulationCalculatorPageViewModel Owner { get; set; }

		public string Key => Model?.Key;
		public string DisplayName => Model?.DisplayName;
		public string Tier => new string('I', Model?.Tier ?? 0);

		public int Count
		{
			get { return mCount; }
			set
			{
				if (value == mCount) return;
				mCount = value;
				OnPropertyChanged();
				Owner?.UpdateValues();
			}
		}

		public int TurnaroundThreshold
		{
			get { return mTurnaroundThreshold; }
			set
			{
				if (value == mTurnaroundThreshold) return;
				mTurnaroundThreshold = value;
				OnPropertyChanged();
			}
		}
	}
}