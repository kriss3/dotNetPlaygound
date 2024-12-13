using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace ConAppSimpleLib;

public class MyConfig
{
    //create async function that connect to Azure Key Vault and retrievs a value
    public static async Task<string> GetSecretAsync(string secretName)
    {
        //create a client to connect to Azure Key Vault
        var client = new SecretClient(new Uri("https://mykeyvault2021.vault.azure.net/"), new DefaultAzureCredential());
        //retrieve a secret
        KeyVaultSecret secret = await client.GetSecretAsync(secretName);
        //return the secret value
        return secret.Value;
    }
}
