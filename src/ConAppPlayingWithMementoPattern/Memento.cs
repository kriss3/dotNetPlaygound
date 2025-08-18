using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithMementoPattern;
public class Memento
{
	private string _state;

	public Memento(string state)
	{
		_state = state;
	}
}
