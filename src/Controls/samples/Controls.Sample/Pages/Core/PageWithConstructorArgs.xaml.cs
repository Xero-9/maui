using Maui.Controls.Sample.Pages.Base;
using Maui.Controls.Sample.ViewModels.Base;

using Microsoft.Maui;
using Microsoft.Maui.Controls.Xaml;

namespace Maui.Controls.Sample.Pages
{
	public class SomeViewModel : BaseViewModel
	{
		//public string Text { get; set; } = "Hello World";
		private string _text;
		public string Text { get => _text; set => base.SetProperty(ref _text, value); }
		public SomeViewModel()
		{
			Text = "Hello World";
		}
	}
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageWithConstructorArgs : BasePage
	{

		//public PageWithConstructorArgs()
		//{
		//	InitializeComponent();
		//	BindingContext = this;
		//	SomeDataText = "Hello World";
		//}
		public PageWithConstructorArgs(SomeViewModel someViewModel)
		{
			InitializeComponent();
			BindingContext = someViewModel;
		}
	}
}