using ConAppMediatorPattern.Structural;
using static System.Console;

namespace ConAppMediatorPattern;

public class Program
{
	static void Main(string[] args)
	{
		
	}



	private static void StructuralExample()
	{
		WriteLine("Project to learn more about this Behavioral Pattern.");
		WriteLine("Based on PluralSight Course by: Steve Michelotti");
		var mediator = new ConcreteMediator();

		var c1 = mediator.CreateColleague<Colleague1>();
		var c2 = mediator.CreateColleague<Colleague2>();

		c1.Send("Hello from Colleague1");
		c2.Send("Hello from Colleague2");
	}
}
