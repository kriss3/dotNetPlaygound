namespace ConAppPlayingWithLambda;

public class Program
{
	static async Task Main() => await Task.Run(() => Console.WriteLine("Lambda Expressions"));

	public static List<UdfCurrency> GetUdfCurrencies()
	{
		return
		[
			new UdfCurrency { Code = "USD", Description = "United States Dollar" },
		new UdfCurrency { Code = "EUR", Description = "Euro" },
		new UdfCurrency { Code = "JPY", Description = "Japanese Yen" },
		new UdfCurrency { Code = "GBP", Description = "British Pound" },
		new UdfCurrency { Code = "AUD", Description = "Australian Dollar" },
		new UdfCurrency { Code = "CAD", Description = "Canadian Dollar" },
		new UdfCurrency { Code = "CHF", Description = "Swiss Franc" },
		new UdfCurrency { Code = "CNY", Description = "Chinese Yuan" },
		new UdfCurrency { Code = "SEK", Description = "Swedish Krona" },
		new UdfCurrency { Code = "NZD", Description = "New Zealand Dollar" }
		];
	}

	public static List<MxCurrency> GetMxCurrencies()
	{
		return new List<MxCurrency>
	{
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
	};
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


