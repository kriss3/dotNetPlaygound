﻿using ConAppPlayingWithLambda.Model;
using System.Reflection;
using static System.Console;

namespace ConAppPlayingWithLambda;

public class Program
{
	static async Task Main() => await Task.Run(() =>
	{
		WriteLine("Lambda Expressions");

		ShowCollection(GetUdfCurrencies());
		ShowCollection(GetMxCurrencies());

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

	public static void ShowCollection<T>(IEnumerable<T> dataBag)
	{
			
		foreach (var item in dataBag)
		{
			PropertyInfo[] properties = typeof(T).GetProperties();
			foreach (var prop in properties)
			{
				WriteLine($"{prop.Name}\t{prop.GetValue(item)}");
			}
		}
	}
}


