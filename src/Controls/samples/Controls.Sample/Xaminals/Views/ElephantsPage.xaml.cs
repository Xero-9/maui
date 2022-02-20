using System.Collections.Generic;
using System.Linq;
using Maui.Controls.Sample.Xaminals.Data;
using Maui.Controls.Sample.Xaminals.Models;

using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Xaminals.Views
{
	public partial class ElephantsPage : ContentPage
    {
	    public IList<Animal> Elephants { get; init; }
#if ENABLE_DI_CHANGES
	    public ElephantsPage(IDataStore<ElephantData> elephantData)
        {
            InitializeComponent();
            Elephants = elephantData.Animals;
            BindingContext = this;
        }
#elif USE_PARTIAL_DI
	    public ElephantsPage()
	    {
		    InitializeComponent();
		    Elephants = App.GetService<IDataStore<ElephantData>>().Animals;
		    BindingContext = this;
	    }
#else
	    public ElephantsPage()
	    {
		    InitializeComponent();
		    Elephants = ElephantData.Instance.Animals;
		    BindingContext = this;

	    }
#endif
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string elephantName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"elephantdetails?name={elephantName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/elephants/elephantdetails?name={elephantName}");
        }
    }
}
