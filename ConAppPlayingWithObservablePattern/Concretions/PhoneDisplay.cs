using ConAppPlayingWithObservablePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithObservablePattern.Concretions;
public class PhoneDisplay : IObserver
{
	private readonly IObservable _observable;
	public PhoneDisplay(IObservable observable)
	{
		_observable = observable;
	}
	public Task Update()
	{
		throw new NotImplementedException();
	}
}
