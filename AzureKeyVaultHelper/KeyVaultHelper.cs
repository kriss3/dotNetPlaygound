using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureKeyVaultHelper;
public static class KeyVaultHelper
{
	/// <summary>
	/// Retrieves a secret value from Azure Key Vault using a hardcoded vault URL
	/// </summary>
	/// <param name="secretName">The name of the secret to retrieve</param>
	/// <returns>The secret value, or empty string if error occurred</returns>
	public static async Task<string> GetSecretAsync(string secretName) 
	{
		return await GetSecretAsync("https://mykeyvault2021.vault.azure.net/", secretName);
	}

	public static async Task<string> GetSecretAsync(string vaultUrl, string secretKey) 
	{

	}

	public static async Task<string?> GetSecretOrNullAsync(string vaultUrl, string secretKey) 
	{
	
	}

	public static async Task<bool> SecretExistsAsync(string vaultUrl, string secretKey) 
	{
	
	}

	public static async Task<Dictionary<string, string>> GetMultipleSecretsAsync(string vaultUrl, params string[] secretKeys) 
	{
	
	}

}
