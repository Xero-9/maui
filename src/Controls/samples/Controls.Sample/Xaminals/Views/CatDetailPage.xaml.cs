using System;
using System.Linq;

using Maui.Controls.Sample.Xaminals.Data;
using Maui.Controls.Sample.Xaminals.Models;
using Maui.Controls.Sample.Xaminals.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Xaminals.Views
{
	//[QueryProperty(nameof(Name), "name")]
    public partial class CatDetailPage : ContentPage
    {
		//public string Name
		//{
		//    set
		//    {
		//        LoadAnimal(value);
		//    }
		//}
#if ENABLE_DI_CHANGES || USE_PARTIAL_DI
        public CatDetailPage(CatDetailViewModel catDetailViewModel)
        {
            InitializeComponent();
            BindingContext = catDetailViewModel;
        }
#else
		public CatDetailPage()
		{
			InitializeComponent();
			BindingContext = new CatDetailViewModel();
		}
#endif

		//void LoadAnimal(string name)
		//{
		//    try
		//    {
		//        Animal animal = CatData.Cats.FirstOrDefault(a => a.Name == name);
		//        BindingContext = animal;
		//    }
		//    catch (Exception)
		//    {
		//        Console.WriteLine("Failed to load animal.");
		//    }
		//}
	}
}
