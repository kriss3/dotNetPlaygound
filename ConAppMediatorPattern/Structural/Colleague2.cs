using static System.Console;
namespace ConAppMediatorPattern.Structural;

public class Colleague2(Mediator mediator) : Colleague(mediator)
{
	public override void HandleNotification(string message)
	{
		WriteLine($"Colleague2 receives notification message: {message}");
	}
}
