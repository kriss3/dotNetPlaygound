using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			Console.WriteLine($"State = {_state}");
		}
	}
}
