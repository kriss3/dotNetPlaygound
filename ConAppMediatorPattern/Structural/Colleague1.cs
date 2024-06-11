using static System.Console;
namespace ConAppMediatorPattern.Structural;
public class Colleague1(Mediator mediator) : Colleague(mediator)
{
    public override void HandleNotification(string message)
	{
        WriteLine($"Colleague1 receives notification message: {message}");
	}
}
