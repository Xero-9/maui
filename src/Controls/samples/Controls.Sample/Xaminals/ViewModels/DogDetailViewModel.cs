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


public class DogDetailViewModel: IQueryAttributable, INotifyPropertyChanged
{
	Animal dog;
	IDataStore<DogData> DogData { get; set; }
#if ENABLE_DI_CHANGES || USE_PARTIAL_DI
	public DogDetailViewModel(IDataStore<DogData> dogData)
	{
		DogData = dogData;
	}
#else
	public DogDetailViewModel()
	{
		DogData = Data.DogData.Instance;
	}
#endif
	public Animal Dog
	{
		get => dog;
		private set
		{
			dog = value;
			OnPropertyChanged();
		}
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		// Only a single query parameter is passed, which needs URL decoding.
		var name = HttpUtility.UrlDecode(query["name"].ToString());
		Dog = DogData.LoadAnimal(name);
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