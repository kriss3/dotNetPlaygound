using ConAppPlayingWithLambda.Model;
using static System.Console;

namespace ConAppPlayingWithLambda;

public class Program
{
	static async Task Main() => await Task.Run(() =>
	{
		WriteLine("Lambda Expressions");

		ShowUdfCurrency(GetUdfCurrencies());
		WriteLine();
		ShowMxCollection(GetMxCurrencies());

		WriteLine("Showing Results...");

		var res = Helpers.GetUdfCurrenciesWithDescriptions(GetMxCurrencies(), GetUdfCurrencies());
		foreach (var item in res)
		{
			WriteLine($"{item.Code}\t{item.Description}");
		}
	});

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


	private static void ShowUdfCurrency(List<UdfCurrency> udfCurrencies)
	{
		udfCurrencies.ForEach((item) => WriteLine($"{item.Code}\t{item.Description}"));
	}

	private static void ShowMxCollection(List<MxCurrency> mxCurrencies)
	{
		mxCurrencies.ForEach((item) => WriteLine($"{item.Code}\t{item.Description}"));
	}

	private static void ShowCollectionChunks(List<MxCurrency> mxCurrencies) 
	{
		// use LINQ Chunk extension
		var chunks = mxCurrencies.Chunk(3);
		// print to console each chunk and separate by a line of * using LINQ method
		chunks.ToList().ForEach(chunk =>
		{
			chunk.ToList().ForEach(item => WriteLine($"{item.Code}\t{item.Description}"));
			WriteLine(new string('*', 20));
		});
	}

}


