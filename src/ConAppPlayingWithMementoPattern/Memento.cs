namespace ConAppPlayingWithMementoPattern;
public class Memento(string state)
{
	private readonly string _state = state;

	public string State 
	{
		get { return _state; }
	}
}
