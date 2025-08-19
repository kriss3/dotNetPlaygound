
using static System.Console;

namespace ConAppPlayingWithMementoPattern;
public class Originator
{
	private string? _state;

	public string? State 
	{
		get { return _state; }
		set 
		{
			_state = value;
			WriteLine($"State = {_state}");
		}
	}

	public Memento CreateMemento() 
	{
		return new Memento(_state!);
	}

	// Restore original State:
	public void SetMemento(Memento memento) 
	{
		WriteLine($"Restoring State...");
		State = memento.State;
	}
}
