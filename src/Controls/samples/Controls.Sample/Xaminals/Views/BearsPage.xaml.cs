using System.Collections.Generic;
using System.Linq;
using Maui.Controls.Sample.Xaminals.Data;
using Maui.Controls.Sample.Xaminals.Models;

using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Xaminals.Views
{
	public partial class BearsPage : ContentPage
	{
		public IList<Animal> Bears { get; init; }
#if ENABLE_DI_CHANGES
		public BearsPage(IDataStore<BearData> bearData)
        {
            InitializeComponent();
			Bears = bearData.Animals;
			BindingContext = this;
        }
#elif USE_PARTIAL_DI
		public BearsPage()
		{
			InitializeComponent();
			Bears = App.GetService<IDataStore<BearData>>().Animals;
			BindingContext = this;
		}
#else
		public BearsPage()
		{
			InitializeComponent();
			Bears = BearData.Instance.Animals;
			BindingContext = this;
		}
#endif
		async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string bearName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"beardetails?name={bearName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/bears/beardetails?name={bearName}");
        }
    }
}
