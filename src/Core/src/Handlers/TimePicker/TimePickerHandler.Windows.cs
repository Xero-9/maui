#nullable enable
using Microsoft.UI.Xaml.Controls;
using WBrush = Microsoft.UI.Xaml.Media.Brush;

namespace Microsoft.Maui.Handlers
{
	public partial class TimePickerHandler : ViewHandler<ITimePicker, TimePicker>
	{
		WBrush? _defaultForeground;

		protected override TimePicker CreatePlatformView() => new TimePicker();

		protected override void ConnectHandler(TimePicker platformView)
		{
			platformView.TimeChanged += OnControlTimeChanged;
		}

		protected override void DisconnectHandler(TimePicker platformView)
		{
			platformView.TimeChanged -= OnControlTimeChanged;
		}

		void SetupDefaults(TimePicker platformView)
		{
			_defaultForeground = platformView.Foreground;
		}

		public static void MapFormat(ITimePickerHandler handler, ITimePicker timePicker)
		{
			handler.PlatformView?.UpdateTime(timePicker);
		}

		public static void MapTime(ITimePickerHandler handler, ITimePicker timePicker)
		{
			handler.PlatformView?.UpdateTime(timePicker);
		}

		public static void MapCharacterSpacing(ITimePickerHandler handler, ITimePicker timePicker)
		{
			handler.PlatformView?.UpdateCharacterSpacing(timePicker);
		}

		public static void MapFont(ITimePickerHandler handler, ITimePicker timePicker)
		{
			var fontManager = handler.GetRequiredService<IFontManager>();

			handler.PlatformView?.UpdateFont(timePicker, fontManager);
		}

		public static void MapTextColor(ITimePickerHandler handler, ITimePicker timePicker)
		{
			if (handler is TimePickerHandler platformHandler)
				handler.PlatformView?.UpdateTextColor(timePicker, platformHandler._defaultForeground);
		}

		void OnControlTimeChanged(object? sender, TimePickerValueChangedEventArgs e)
		{
			if (VirtualView != null)
			{
				VirtualView.Time = e.NewTime;
				VirtualView.InvalidateMeasure();
			}
		}
	}
}