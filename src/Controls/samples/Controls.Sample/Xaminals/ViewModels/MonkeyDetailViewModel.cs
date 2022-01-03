using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

using Maui.Controls.Sample.Xaminals.Data;
using Maui.Controls.Sample.Xaminals.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Xaminals.ViewModels
{
	public class MonkeyDetailViewModel : IQueryAttributable, INotifyPropertyChanged
	{
		Animal monkey;
		public IDataStore<MonkeyData> MonkeyData { get; init; }
#if ENABLE_DI_CHANGES || USE_PARTIAL_DI
		public MonkeyDetailViewModel(IDataStore<MonkeyData> monkeyData)
		{
			MonkeyData = monkeyData;
		}
#else
		public MonkeyDetailViewModel()
		{
			MonkeyData = Data.MonkeyData.Instance;
		}
#endif
		public Animal Monkey
		{
			get => monkey;
			private set
			{
				monkey = value;
				OnPropertyChanged();
			}
		}

		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			// Only a single query parameter is passed, which needs URL decoding.
			var name = HttpUtility.UrlDecode(query["name"].ToString());
			Monkey = MonkeyData.LoadAnimal(name);
		}
#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

#endregion
	}
}
