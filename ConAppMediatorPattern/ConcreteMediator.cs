using ConAppMediatorPattern.Structural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppMediatorPattern; 
public class ConcreteMediator: Mediator
{
	private readonly List<Colleague> colleagues = [];

	public void Register(Colleague colleague)
	{
		colleague.SetMediator(this);
		this.colleagues.Add(colleague);
	}

	public override void Send(string message, Colleague colleague)
	{
		this.colleagues
			.Where(c => c != colleague)
			.ToList()
			.ForEach(c => c.HandleNotification(message));
	}
}
