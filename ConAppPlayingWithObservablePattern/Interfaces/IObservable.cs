namespace ConAppPlayingWithObservablePattern.Interfaces;
public interface IObservable
{
	Task Add(IObserver observer);
	Task Remove(IObserver observer);
	Task Notify(); 
}
