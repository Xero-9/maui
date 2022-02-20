#define ENABLE_DI_CHANGES
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
	public class BearDetailViewModel : IQueryAttributable, INotifyPropertyChanged
	{
		public IDataStore<BearData> BearData { get; init; }
#if ENABLE_DI_CHANGES || USE_PARTIAL_DI

		public BearDetailViewModel(IDataStore<BearData> bearData)
		{
			BearData = bearData;
		}
#else
		public BearDetailViewModel()
		{
			BearData = Data.BearData.Instance;
		}
#endif
		Animal bear;
		public Animal Bear
		{
			get => bear;
			private set
			{
				bear = value;
				OnPropertyChanged();
			}
		}

		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			// Only a single query parameter is passed, which needs URL decoding.
			var name = HttpUtility.UrlDecode(query["name"].ToString());
			Bear = BearData.LoadAnimal(name);
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
