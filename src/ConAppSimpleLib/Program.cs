using ConAppSimpleLib.ExamplesDoFactory;
using Microsoft.Extensions.Configuration;
using static System.Console;

namespace ConAppSimpleLib;
public class Program
{
	public static async Task Main()
	{
		
		await ExploreCollections();
		MySerializer.DoSerialize();
		MySerializer.DoSerialize(CreatePersonInstance());



		// Need to make below execution optional.
		bool flowControl = await GetAzureConfigurationValue();
		if (!flowControl)
		{
			return;
		}
	}

	private static PersonObj CreatePersonInstance() 
	{
		var firstName = "Jack";
		var lastName = "Black";
		var emailAddress = "JackB@no_email.com";
		var year = 1977;
		var month = 1;
		var day = 1;
		return new PersonObj(firstName, lastName, emailAddress, year, month, day);
	}

	private static async Task<bool> GetAzureConfigurationValue()
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
			return false;
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

		return true;
	}

	private static Task ExploreCollections() 
	{
		// Example collections
		var list1 = new List<int> { 1, 2, 3 };
		var list2 = new List<int> { 4, 5, 6 };

		var collService = new CollectionService();

		// Combine
		var combined = collService.CombineCollections(list1, list2);
		WriteLine("Combined: " + string.Join(", ", combined));

		var evenNumb = collService.GetEvenNumbers(list1);
		WriteLine("Even numbers: " + string.Join(", ", evenNumb));

		return Task.CompletedTask;
	}
}
