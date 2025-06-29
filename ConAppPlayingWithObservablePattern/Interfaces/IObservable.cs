using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithObservablePattern.Interfaces;
internal interface IObservable
{
	Task Add(IObserver observer);
	Task Remove(IObserver observer);
	Task Notify(); 
}
