using Microsoft.Extensions.Configuration;

using static System.Console;

namespace ConAppSimpleLib;
public class Program
{
	public static void Main() 
	{
		WriteLine("My attempt to work with Az Key Vault.");
		// Load configuration from appsettings.json
		var config = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.Build();
	}
}
