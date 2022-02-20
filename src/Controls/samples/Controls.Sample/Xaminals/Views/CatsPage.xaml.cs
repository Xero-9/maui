using System.Collections.Generic;
using System.Linq;
using Maui.Controls.Sample.Xaminals.Data;
using Maui.Controls.Sample.Xaminals.Models;

using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Xaminals.Views
{
	public partial class CatsPage : ContentPage
    {
	    public IList<Animal> Cats { get; init; }
#if ENABLE_DI_CHANGES
	    public CatsPage(IDataStore<CatData> catData)
        {
            InitializeComponent();
			Cats = catData.Animals;
			BindingContext = this;
        }
#elif USE_PARTIAL_DI
		public CatsPage()
		{
			InitializeComponent();
			Cats = App.GetService<IDataStore<CatData>>().Animals;
			BindingContext = this;
		}
#else
		public CatsPage()
		{
			InitializeComponent();
			Cats = CatData.Instance.Animals;
			BindingContext = this;

		}
#endif
		async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string catName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"catdetails?name={catName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/domestic/cats/catdetails?name={catName}");
        }
    }
}
