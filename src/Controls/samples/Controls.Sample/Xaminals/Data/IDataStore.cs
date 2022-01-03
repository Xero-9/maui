using System;
using System.Collections.Generic;
using System.Linq;
using Maui.Controls.Sample.Xaminals.Models;
using Microsoft.Extensions.Logging;

namespace Maui.Controls.Sample.Xaminals.Data;

public interface IDataStore<T> where T : class
{
#if ENABLE_DI_CHANGES || USE_PARTIAL_DI
	ILogger<T> Logger { get; }
#endif
	public IList<Animal> Animals { get; }
	public virtual Animal LoadAnimal(string name)
	{
		Animal animal = null;
		try
		{
			animal = Animals.FirstOrDefault(a => a.Name == name);
		}
#if ENABLE_DI_CHANGES || USE_PARTIAL_DI
		catch (Exception e)
		{
			Logger.LogError(e, "Failed to load animal with {name}.", name);
#else
		catch
		{
			Console.WriteLine("Failed to load animal with {name}.", name);
#endif
		}
		return animal;
	}
}