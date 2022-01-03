using System.Collections.Generic;
using System.Linq;
using Maui.Controls.Sample.Xaminals.Data;
using Maui.Controls.Sample.Xaminals.Models;

using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Xaminals.Views
{
	public partial class DogsPage : ContentPage
    {
	    public IList<Animal> Dogs { get; init; }
#if ENABLE_DI_CHANGES
	    public DogsPage(IDataStore<DogData> dogData)
        {
            InitializeComponent();
			Dogs = dogData.Animals;
			BindingContext = this;
        }
#elif USE_PARTIAL_DI
	    public DogsPage()
	    {
		    InitializeComponent();
		    Dogs = App.GetService<IDataStore<DogData>>().Animals;
		    BindingContext = this;
	    }
#else
	    public DogsPage()
	    {
		    InitializeComponent();
		    Dogs = DogData.Instance.Animals;
		    BindingContext = this;

	    }
#endif
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string dogName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"dogdetails?name={dogName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/domestic/dogs/dogdetails?name={dogName}");
        }
    }
}
