using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
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

	/// <summary>
	/// Retrieves a secret value from Azure Key Vault
	/// </summary>
	/// <param name="vaultUrl">The Azure Key Vault URL</param>
	/// <param name="secretKey">The name of the secret to retrieve</param>
	/// <returns>The secret value, or empty string if error occurred</returns>
	public static async Task<string> GetSecretAsync(string vaultUrl, string secretKey) 
	{
		if (string.IsNullOrEmpty(vaultUrl))
			throw new ArgumentException("Vault URL cannot be null or empty", nameof(vaultUrl));

		if (string.IsNullOrEmpty(secretKey))
			throw new ArgumentException("Secret key cannot be null or empty", nameof(secretKey));

		try
		{
			var client = new SecretClient(new Uri(vaultUrl), new DefaultAzureCredential());
			KeyVaultSecret secret = await client.GetSecretAsync(secretKey);
			return secret.Value;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error retrieving secret: {ex.Message}");
			return string.Empty;
		}

	}

	/// <summary>
	/// Retrieves a secret value from Azure Key Vault with nullable return
	/// </summary>
	/// <param name="vaultUrl">The Azure Key Vault URL</param>
	/// <param name="secretKey">The name of the secret to retrieve</param>
	/// <returns>The secret value, or null if error occurred</returns>
	public static async Task<string?> GetSecretOrNullAsync(string vaultUrl, string secretKey) 
	{
		if (string.IsNullOrEmpty(vaultUrl))
			throw new ArgumentException("Vault URL cannot be null or empty", nameof(vaultUrl));

		if (string.IsNullOrEmpty(secretKey))
			throw new ArgumentException("Secret key cannot be null or empty", nameof(secretKey));

		try
		{
			var client = new SecretClient(new Uri(vaultUrl), new DefaultAzureCredential());
			KeyVaultSecret secret = await client.GetSecretAsync(secretKey);
			return secret.Value;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error retrieving secret: {ex.Message}");
			return null;
		}

	}

	/// <summary>
	/// Checks if a secret exists in Azure Key Vault
	/// </summary>
	/// <param name="vaultUrl">The Azure Key Vault URL</param>
	/// <param name="secretKey">The name of the secret to check</param>
	/// <returns>True if secret exists, false otherwise</returns>

	public static async Task<bool> SecretExistsAsync(string vaultUrl, string secretKey) 
	{
		try
		{
			var client = new SecretClient(new Uri(vaultUrl), new DefaultAzureCredential());
			await client.GetSecretAsync(secretKey);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static async Task<Dictionary<string, string>> GetMultipleSecretsAsync(string vaultUrl, params string[] secretKeys) 
	{
	
	}

}
