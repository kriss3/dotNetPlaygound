namespace ConAppSimpleLib.Infrastructure;
public class AppSettings
{
	public Configuration? Configuration { get; set; }
}

public class Configuration 
{
	public string AzureVaultUrl { get; set; } = string.Empty;
}
