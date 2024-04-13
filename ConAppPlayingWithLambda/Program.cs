namespace ConAppPlayingWithLambda;

public class Program
{
	static async Task Main() => await Task.Run(() => Console.WriteLine("Lambda Expressions"));

	public static List<UdfCurrency> GetUdfCurrencies()
	{
		return
		[
			new UdfCurrency { Code = "USD", Description = "" },
			new UdfCurrency { Code = "EUR", Description = "" },
			new UdfCurrency { Code = "JPY", Description = "" },
			new UdfCurrency { Code = "GBP", Description = "" },
			new UdfCurrency { Code = "AUD", Description = "" },
			new UdfCurrency { Code = "CAD", Description = "" },
			new UdfCurrency { Code = "CHF", Description = "" },
			new UdfCurrency { Code = "CNY", Description = "" },
			new UdfCurrency { Code = "SEK", Description = "" },
			new UdfCurrency { Code = "NZD", Description = "" }
		];
	}

	public static List<MxCurrency> GetMxCurrencies()
	{
		return
			[
		new MxCurrency { Code = "MXN", Description = "Mexican Peso" },
		new MxCurrency { Code = "USD", Description = "United States Dollar" },
		new MxCurrency { Code = "EUR", Description = "Euro" },
		new MxCurrency { Code = "JPY", Description = "Japanese Yen" },
		new MxCurrency { Code = "GBP", Description = "British Pound" },
		new MxCurrency { Code = "AUD", Description = "Australian Dollar" },
		new MxCurrency { Code = "CAD", Description = "Canadian Dollar" },
		new MxCurrency { Code = "CHF", Description = "Swiss Franc" },
		new MxCurrency { Code = "CNY", Description = "Chinese Yuan" },
		new MxCurrency { Code = "SEK", Description = "Swedish Krona" }
		];
	}
}

public class MxCurrency 
{
	public string? Code { get; set; }
    public string? Description { get; set; }
}

public class UdfCurrency 
{
    public string? Code { get; set; }
    public string? Description { get; set; }
}


