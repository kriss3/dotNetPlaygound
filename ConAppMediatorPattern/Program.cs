using ConAppMediatorPattern.Structural;
using static System.Console;

namespace ConAppMediatorPattern;

public class Program
{
	static void Main(string[] args)
	{
		WriteLine("Project to learn more about this Behavioral Pattern.");
		WriteLine("Based on PluralSight Course by: Steve Michelotti");
		var mediator = new ConcreteMediator();
		var c1 = new Colleague1(mediator);
		var c2 = new Colleague2(mediator);

		mediator.Colleague1 = c1;
		mediator.Colleague2 = c2;

		c1.Send("Hello from Colleague1");
		c2.Send("Hello from Colleague2");
	}
}
