using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maui.Controls.Sample.Xaminals.Models;

using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Xaminals.Controls
{
	public class AnimalSearchHandler : SearchHandler
	{
		public static BindableProperty AnimalsProperty =
			BindableProperty.Create(nameof(Animals), typeof(IList<Animal>), typeof(AnimalSearchHandler), default(IList<Animal>), BindingMode.Default);

		public IList<Animal> Animals
		{
			get => (IList<Animal>)GetValue(AnimalsProperty);
			set => SetValue(AnimalsProperty, value);
		}

		public Type SelectedItemNavigationTarget { get; set; }

		protected override void OnQueryChanged(string oldValue, string newValue)
		{
			base.OnQueryChanged(oldValue, newValue);

			if (string.IsNullOrWhiteSpace(newValue))
			{
				ItemsSource = Animals != null ? Animals : (System.Collections.IEnumerable)null;
			}
			else
			{
				ItemsSource = Animals
					.Where(animal => animal.Name.ToLower().Contains(newValue.ToLower()))
					.ToList();
			}
		}

		protected override async void OnItemSelected(object item)
		{
			base.OnItemSelected(item);

			// Let the animation complete
			await Task.Delay(1000);

			ShellNavigationState state = (Application.Current.MainPage as Shell).CurrentState;
			// The following route works because route names are unique in this application.
			await Shell.Current.GoToAsync($"{GetNavigationTarget()}?name={((Animal)item).Name}");
		}
		string GetNavigationTarget()
		{
			return (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
		}
	}
}
