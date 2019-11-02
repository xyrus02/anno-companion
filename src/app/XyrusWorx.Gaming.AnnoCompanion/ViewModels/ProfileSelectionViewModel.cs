using System.Collections.Generic;
using System.Collections.ObjectModel;
using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.Windows.ViewModels;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class ProfileSelectionViewModel : CollectionViewModel<ObjectStoreModel>
	{
		public ProfileSelectionViewModel()
		{
			Selection = new SelectionViewModel<ObjectStoreModel>(this);
		}

		public SelectionViewModel<ObjectStoreModel> Selection { get;  }
		public override IList<ObjectStoreModel> Items { get; } = new ObservableCollection<ObjectStoreModel>();
	}
}
