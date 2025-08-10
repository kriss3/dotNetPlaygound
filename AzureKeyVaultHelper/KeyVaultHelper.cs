using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureKeyVaultHelper;
public static class KeyVaultHelper
{
	public static async Task<string> GetSecretAsync(string secretName) { }

	public static async Task<string> GetSecretAsync(string vaultUrl, string secretKey) { }

	public static async Task<string?> GetSecretOrNullAsync(string vaultUrl, string secretKey) { }

	public static async Task<bool> SecretExistsAsync(string vaultUrl, string secretKey) { }

	public static async Task<Dictionary<string, string>> GetMultipleSecretsAsync(string vaultUrl, params string[] secretKeys) { }

}
