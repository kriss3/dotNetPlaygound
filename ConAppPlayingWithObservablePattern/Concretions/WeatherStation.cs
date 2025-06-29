using ConAppPlayingWithObservablePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithObservablePattern.Concretions;
public class WeatherStation : IObservable
{
	public Task Add(IObserver observer)
	{
		throw new NotImplementedException();
	}

	public Task Notify()
	{
		throw new NotImplementedException();
	}

	public Task Remove(IObserver observer)
	{
		throw new NotImplementedException();
	}
}
