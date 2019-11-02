using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.Components
{
	[PublicAPI]
	public class InputField : TextBox
	{
		public static readonly DependencyProperty LabelProperty =
			DependencyProperty.Register("Label", typeof(object),
				typeof(InputField), new FrameworkPropertyMetadata(null, 
					FrameworkPropertyMetadataOptions.AffectsArrange |
					FrameworkPropertyMetadataOptions.AffectsMeasure | 
					FrameworkPropertyMetadataOptions.AffectsRender));

		static InputField()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(InputField), new FrameworkPropertyMetadata(typeof(InputField)));
		}
		public InputField()
		{
			AddHandler(PreviewMouseLeftButtonDownEvent,
				new MouseButtonEventHandler(SelectivelyIgnoreMouseButton), true);
			AddHandler(GotKeyboardFocusEvent,
				new RoutedEventHandler(SelectAllText), true);
			AddHandler(MouseDoubleClickEvent,
				new RoutedEventHandler(SelectAllText), true);
		}

		public object Label
		{
			get => (object)GetValue(LabelProperty);
			set => SetValue(LabelProperty, value);
		}

		private void SelectivelyIgnoreMouseButton(object sender, MouseButtonEventArgs e)
		{
			if (!IsKeyboardFocusWithin)
			{
				// If the text box is not yet focussed, give it the focus and
				// stop further processing of this click event.
				Focus();
				e.Handled = true;
			}
		}
		private void SelectAllText(object sender, RoutedEventArgs e)
		{
			SelectAll();
		}
	}
}
