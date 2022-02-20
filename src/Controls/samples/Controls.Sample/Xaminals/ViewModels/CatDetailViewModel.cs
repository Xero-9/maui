using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Maui.Controls.Sample.Xaminals.Data;
using Maui.Controls.Sample.Xaminals.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Xaminals.ViewModels;

public class CatDetailViewModel : IQueryAttributable, INotifyPropertyChanged
{
	Animal cat;
	public IDataStore<CatData> CatData { get; init; }
#if ENABLE_DI_CHANGES || USE_PARTIAL_DI
	public CatDetailViewModel(IDataStore<CatData> catData)
	{
		CatData = catData;
	}
#else
	public CatDetailViewModel()
	{
		CatData = Data.CatData.Instance;
	}
#endif

	public Animal Cat
	{
		get => cat;
		private set
		{
			cat = value;
			OnPropertyChanged();
		}
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		// Only a single query parameter is passed, which needs URL decoding.
		var name = HttpUtility.UrlDecode(query["name"].ToString());
		Cat = CatData.LoadAnimal(name);
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