using System;
using System.Linq;

using Maui.Controls.Sample.Xaminals.Data;
using Maui.Controls.Sample.Xaminals.Models;
using Maui.Controls.Sample.Xaminals.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Xaminals.Views
{
	public partial class ElephantDetailPage : ContentPage
    {
#if ENABLE_DI_CHANGES || USE_PARTIAL_DI
        public ElephantDetailPage(ElephantDetailViewModel elephantDetailViewModel)
        {
            InitializeComponent();
            BindingContext = elephantDetailViewModel;
        }
#else
		public ElephantDetailPage()
		{
			InitializeComponent();
			BindingContext = new ElephantDetailViewModel();
		}
#endif
	}
}
