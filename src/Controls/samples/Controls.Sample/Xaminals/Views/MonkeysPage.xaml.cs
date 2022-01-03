using System.Collections.Generic;
using System.Linq;
using Maui.Controls.Sample.Xaminals.Data;
using Maui.Controls.Sample.Xaminals.Models;

using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Xaminals.Views
{
	public partial class MonkeysPage : ContentPage
    {
		public IList<Animal> Monkeys { get; init; }
#if ENABLE_DI_CHANGES
        public MonkeysPage(IDataStore<MonkeyData> monkeyData)
        {
            InitializeComponent();
            Monkeys = monkeyData.Animals;
            BindingContext = this;
        }
#elif USE_PARTIAL_DI
        public MonkeysPage()
        {
	        InitializeComponent();
	        Monkeys = App.GetService<IDataStore<MonkeyData>>().Animals;
	        BindingContext = this;
        }
#else
        public MonkeysPage()
        {
	        InitializeComponent();
	        Monkeys = MonkeyData.Instance.Animals;
	        BindingContext = this;

        }
#endif
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string monkeyName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"monkeydetails?name={monkeyName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/monkeys/monkeydetails?name={monkeyName}");
        }
    }
}
