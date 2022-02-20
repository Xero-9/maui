using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Maui.Controls.Sample.Xaminals.Data;
using Maui.Controls.Sample.Xaminals.ViewModels;
using Maui.Controls.Sample.Xaminals.Views;

using Microsoft.Extensions.DependencyInjection;

namespace Maui.Controls.Sample.Xaminals
{
	static class XaminalsRegistrationExtensions
	{

		internal static void RegisterXaminalsViewAndViewModels(this IServiceCollection services)
		{
			services.AddTransient<AboutPage>();
			services.AddTransient<BearsPage>();
			services.AddTransient<BearDetailPage>();
			services.AddTransient<BearDetailViewModel>();
			services.AddTransient<CatsPage>();
			services.AddTransient<CatDetailPage>();
			services.AddTransient<CatDetailViewModel>();
			services.AddTransient<DogsPage>();
			services.AddTransient<DogDetailPage>();
			services.AddTransient<DogDetailViewModel>();
			services.AddTransient<ElephantsPage>();
			services.AddTransient<ElephantDetailPage>();
			services.AddTransient<ElephantDetailViewModel>();
			services.AddTransient<MonkeysPage>();
			services.AddTransient<MonkeyDetailPage>();
			services.AddTransient<MonkeyDetailViewModel>();
		}

		internal static void RegisterXaminalsDataStores(this IServiceCollection services)
		{
			services.AddSingleton<IDataStore<BearData>, BearData>();
			services.AddSingleton<IDataStore<CatData>, CatData>();
			services.AddSingleton<IDataStore<DogData>, DogData>();
			services.AddSingleton<IDataStore<ElephantData>, ElephantData>();
			services.AddSingleton<IDataStore<MonkeyData>, MonkeyData>();
		}

	}
}
