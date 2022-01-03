using System;
using System.Collections.Generic;
using System.Windows.Input;
//using Maui.Controls.Sample.Xaminals.Data;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

using Maui.Controls.Sample.Xaminals.Views;

namespace Maui.Controls.Sample.Xaminals
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
        public ICommand HelpCommand => new Command<string>(execute: async (url) =>
		{
			//#if ANDROID
			//#else
			await Launcher.OpenAsync(url);
			//#endif
		});

        public AppShell()
        {
            InitializeComponent();
			RegisterRoutes();
            BindingContext = this;
        }
        void RegisterRoutes()
        {

	        Routes.Add("monkeydetails", typeof(MonkeyDetailPage));
			Routes.Add("beardetails", typeof(BearDetailPage));
			Routes.Add("catdetails", typeof(CatDetailPage));
	        Routes.Add("dogdetails", typeof(DogDetailPage));
			Routes.Add("elephantdetails", typeof(ElephantDetailPage));

			foreach (var item in Routes)
	        {
#if USE_PARTIAL_DI
				Routing.RegisterRoute(item.Key, new CustomRouteFactory(item.Key, item.Value));
#else
		        Routing.RegisterRoute(item.Key, item.Value);
#endif
			}
		}
		//protected override void OnNavigating(ShellNavigatingEventArgs args)
		//{
		//	base.OnNavigating(args);

		//	Cancel any back navigation
		//	if (e.Source == ShellNavigationSource.Pop)
		//	{
		//		e.Cancel();
		//	}
		//}

		//protected override void OnNavigated(ShellNavigatedEventArgs args)
		//{
		//	base.OnNavigated(args);

		//	// Perform required logic
		//}
	}
}
