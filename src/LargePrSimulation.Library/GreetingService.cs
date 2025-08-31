namespace LargePrSimulation.Library;

public class GreetingService
{
	public static string GetGreeting(string name) => $"Hello, {name}! " + 
		$"and now the sun is shining on {name}";
}
