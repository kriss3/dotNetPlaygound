using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppMediatorPattern.Structural;
public abstract class Colleague
{
	protected Mediator mediator;

    protected Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public virtual void Send(string message)
	{
		mediator.Send(message, this);
	}

    public abstract void HandleNotification(string message);
}
