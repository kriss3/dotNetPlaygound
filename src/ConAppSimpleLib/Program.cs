using Microsoft.Extensions.Configuration;
using static System.Console;

namespace ConAppSimpleLib;
public class Program
{
	public static async Task Main() 
	{
		WriteLine("My attempt to work with Az Key Vault.");
		// Load configuration from appsettings.json
		var config = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.Build();

		string vaultUrl = config["Configuration:AzureVaultUrl"]!;

		if (string.IsNullOrEmpty(vaultUrl)) 
		{
			WriteLine("Vault URL not found in configuration.");
			return;
		}

		// Capture errors correctly when DefaultAuthentication did not work due to:
		/*
		 * Error retrieving secret: DefaultAzureCredential failed to retrieve a token from the included credentials. See the troubleshooting guide for more information. 
		 */
		string? secret = await MyConfig.GetSecretAsync(vaultUrl, "kwsConnString");

		if (secret != null)
		{
			WriteLine("Retrieved Secret:");
			WriteLine(secret);
		}
		else
		{
			WriteLine("Failed to retrieve secret.");
		}
	}
}
