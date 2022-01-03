using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Maui.Controls.Sample.Xaminals.ViewModels;

namespace Maui.Controls.Sample.Xaminals.Views
{
    public partial class MonkeyDetailPage : ContentPage
    {
#if ENABLE_DI_CHANGES || USE_PARTIAL_DI

        public MonkeyDetailPage(MonkeyDetailViewModel monkeyDetailViewModel)
        {
            InitializeComponent();
			BindingContext = monkeyDetailViewModel;
		}
#else
		public MonkeyDetailPage()
		{
			InitializeComponent();
			BindingContext = new MonkeyDetailViewModel();
		}
#endif
	}
}