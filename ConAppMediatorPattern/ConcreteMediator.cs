using ConAppMediatorPattern.Structural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppMediatorPattern; 
public class ConcreteMediator: Mediator
{
	public Colleague1? Colleague1 { get; set; }	
	public Colleague2? Colleague2 { get; set; }

	public override void Send(string message, Colleague colleague)
	{
		if (colleague is Colleague1)
		{
			Colleague2?.HandleNotification(message);
		}
		else if (colleague is Colleague2)
		{
			Colleague1?.HandleNotification(message);
		}
		else 
		{
		}
	}
}
