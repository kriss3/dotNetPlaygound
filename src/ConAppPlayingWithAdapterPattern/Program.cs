using ConAppPlayingWithAdapterPattern.Example_1;
using ConAppPlayingWithAdapterPattern.Example_2;
using ConAppPlayingWithAdapterPattern.Example_3;
using static System.Console;

namespace ConAppPlayingWithAdapterPattern;

public class Program
{
	static async Task Main()
	{
		var examples = new (string Title, Action Run)[]
		{
			("Example 1 — Basic Adapter", Execute_Example_1),
			("Example 2 — Payment Adapter", Execute_Example_2),
			("Example 3 — Logger Adapter", Execute_Example_3),
		};

		foreach (var (title, run) in examples)
		{
			WriteLine("------------------------------------------------------------");
			WriteLine(title);
			Write("Press Enter to run, or 'q' + Enter to exit: ");
			var input = ReadLine();

			if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
				break;

			run();
			Write("Press Enter for next example, or 'q' + Enter to quit: ");
			input = ReadLine();
			if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
				break;
		}
		await Task.CompletedTask;
	}

	private static void Execute_Example_1() 
	{
		Target target = new Adapter();
		target.Request();
		// Wait for user
		ReadKey();
	}

	private static void Execute_Example_2() 
	{
		var checkout = new CheckoutService(new LegacyGatewayAdapter(new LegacyGateway()));
		var ok = checkout.PayOrder("4111111111111111", 49.99m);
		WriteLine($"The payment via Payment Adapter went: {ok}");
	}

	private static void Execute_Example_3()
	{
		var service = new ReportService(new XmlLoggerAdapter());
		service.Run();
		WriteLine($"Example 2 — Logging: adapt an XML-only logger to ILogger ");
	}
}
