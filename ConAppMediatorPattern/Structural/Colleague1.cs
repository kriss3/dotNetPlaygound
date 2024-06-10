using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
namespace ConAppMediatorPattern.Structural;
public class Colleague1 : Colleague
{
    public Colleague1(Mediator mediator): base(mediator)
    {
            
    }
    public override void HandleNotification(string message)
	{
        WriteLine($"Colleague1 receives notification message: {message}");
	}
}
