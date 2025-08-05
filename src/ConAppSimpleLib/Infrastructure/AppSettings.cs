using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppSimpleLib.Infrastructure;
public class AppSettings
{
	public Configuration? Configuration { get; set; }
}

public class Configuration 
{
	public string AzureVaultUrl { get; set; } = string.Empty;
}
