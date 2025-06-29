using ConAppPlayingWithObservablePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithObservablePattern.Concretions;
public class WeatherStation : IObservable
{
	private readonly IList<IObserver> observers = [];
	private readonly int _temperature = 15;

	public Task Add(IObserver observer)
	{
		observers.Add(observer);
		return Task.CompletedTask;
	}

	public Task Remove(IObserver observer)
	{
		if (observers.Count == 0) return Task.CompletedTask;
		observers.Remove(observer);
		return Task.CompletedTask;
	}

	public Task Notify()
	{
		observers.ToList().ForEach(observer => observer.Update());
		return Task.CompletedTask;
	}

	public int GetTemperature()
	{
		return _temperature;
	}
}
