using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public abstract class Constraint : INotifyPropertyChanged
	{
		private event PropertyChangedEventHandler PropertyChanged;

		public event Action<Constraint> Changed;
		public abstract object Enforce(object value);

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			Changed?.Invoke(this);
		}
		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
		{
			add { PropertyChanged += value; }
			remove { PropertyChanged -= value; }
		}
	}
}