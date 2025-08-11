using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using AzureKeyVaultHelper;
using static System.Console;

namespace ConAppSimpleLib;

public class MyConfig
{
	/// <summary>
	/// Gets a secret from the default vault URL
	/// </summary>
	/// <param name="secretName">The name of the secret to retrieve</param>
	/// <returns>The secret value, or empty string if error occurred</returns>
	public static async Task<string> GetSecretAsync(string secretName)
    {
        var result = await KeyVaultHelper.GetSecretAsync(secretName);
        return result;
    }

	/// <summary>
	/// Gets a secret from a specific vault URL
	/// </summary>
	/// <param name="vaultUrl">The Azure Key Vault URL</param>
	/// <param name="secretKey">The name of the secret to retrieve</param>
	/// <returns>The secret value, or empty string if error occurred</returns>
	public static async Task<string> GetSecretAsync(string vaultUrl, string secretKey)
	{
		return await KeyVaultHelper.GetSecretAsync(vaultUrl, secretKey);
	}

	/// <summary>
	/// Gets a secret that might be null
	/// </summary>
	/// <param name="vaultUrl">The Azure Key Vault URL</param>
	/// <param name="secretKey">The name of the secret to retrieve</param>
	/// <returns>The secret value, or null if error occurred</returns>
	public static async Task<string?> GetSecretOrNullAsync(string vaultUrl, string secretKey)
	{
		return await KeyVaultHelper.GetSecretOrNullAsync(vaultUrl, secretKey);
	}
}
