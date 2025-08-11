using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using AzureKeyVaultHelper;
using static System.Console;

namespace ConAppSimpleLib;

public class MyConfig
{
    //create async function that connect to Azure Key Vault and retrieves a value
    public static async Task<string> GetSecretAsync(string secretName)
    {
        var result = await KeyVaultHelper.GetSecretAsync(secretName);
        return result;
    }

    public static async Task<string> GetSecretAsync(string vaultUrl, string secretKey) 
    {
        //az key vault client:
        var client = new SecretClient(new Uri(vaultUrl), new DefaultAzureCredential());

        try
        {
            KeyVaultSecret secret = await client.GetSecretAsync(secretKey);
            return secret.Value;
        }
        catch (Exception ex)
        {
			WriteLine($"Error retrieving secret: {ex.Message}");
            return string.Empty;
        }
    }
}
