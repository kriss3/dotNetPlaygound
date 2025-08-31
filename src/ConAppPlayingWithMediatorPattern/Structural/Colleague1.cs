using static System.Console;
namespace ConAppPlayingWithMediatorPattern.Structural;
public class Colleague1() : Colleague
{
    public override void HandleNotification(string message)
	{
        WriteLine($"Colleague1 receives notification message: {message}");
	}
}
