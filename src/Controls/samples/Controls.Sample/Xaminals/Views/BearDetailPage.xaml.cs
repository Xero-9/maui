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
    public partial class BearDetailPage : ContentPage
    {
#if ENABLE_DI_CHANGES || USE_PARTIAL_DI
		public BearDetailPage(BearDetailViewModel bearDetailViewModel)
		{
			InitializeComponent();
			BindingContext = bearDetailViewModel;
		}
#else
		public BearDetailPage()
		{
			InitializeComponent();
			//BearData = new BearData();
			BindingContext = new BearDetailViewModel();
		}
		//public string Name
		//{
		//	set
		//	{
		//		BearData.LoadAnimal(value);
		//		LoadAnimal(value);
		//	}
		//}

		//public BearData BearData { get; }

		//void LoadAnimal(string name)
		//{
		//	try
		//	{
		//		Animal animal = BearData.Animals.FirstOrDefault(a => a.Name == name);
		//		BindingContext = animal;
		//	}
		//	catch (Exception)
		//	{
		//		Console.WriteLine("Failed to load animal.");
		//	}
		//}
#endif
	}
}
