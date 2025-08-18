using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithMementoPattern;
public class Caretaker
{
	private Memento? _memento;

	public Memento? Memento
	{
		get { return _memento; }
		set { _memento = value; }
	}
}
