﻿using ConAppPlayingWithLambda.Model;

namespace ConAppPlayingWithLambda;
public static class Helpers
{
	public static IEnumerable<UdfCurrency> GetUdfCurrenciesWithDescriptions(
		List<MxCurrency> mxCurrencies, List<UdfCurrency> udfCurrencies)
	{
		List<UdfCurrency> results = [];

		// find all Udf currencies that have a matching Mx currency and do not have Description, create a new version of UdfCurrency with the description taken from MxCurrency and push it to the results List

		foreach (var udfCurrency in udfCurrencies)
		{
			var mxCurrency = mxCurrencies.FirstOrDefault(x => x.Code == udfCurrency.Code);
			if (mxCurrency != null && string.IsNullOrEmpty(udfCurrency.Description))
			{
				results.Add(new UdfCurrency { Code = udfCurrency.Code, Description = mxCurrency.Description });
			}
		}
		return results;
	}

	//LINQ Where
	public static IEnumerable<MxCurrency> FilterCollection()
	{
		return GetMxCurrencies().Where(r => r.Code == "NZD");
	}

	//LINQ Project
	public static MxCurrency ReshapeCollection()
	{
		//using select new or just Select...
		var rec = GetMxCurrencies().ToList();
		return rec.Select(x => new MxCurrency { Code = x.Code, Description = x.Description }).FirstOrDefault()
			?? new MxCurrency();
	}

	//LINQ Order Collection members
	public static IEnumerable<MxCurrency> OrderMemberCollection()
	{
		return GetMxCurrencies()
			.OrderBy(x => x.Code)
			.ThenBy(x => x.Description).ToList();
	}

	private static IEnumerable<MxCurrency> GetMxCurrencies()
	{
		return
		[
			new() { Code = "USD", Description = "United States Dollar" },
			new() { Code = "EUR", Description = "Euro" },
			new() { Code = "GBP", Description = "British Pound" },
			new() { Code = "JPY", Description = "Japanese Yen" },
			new() { Code = "CAD", Description = "Canadian Dollar" },
			new() { Code = "AUD", Description = "Australian Dollar" },
			new() { Code = "CHF", Description = "Swiss Franc" },
			new() { Code = "CNY", Description = "Chinese Yuan" },
			new() { Code = "SEK", Description = "Swedish Krona" },
			new() { Code = "NZD", Description = "New Zealand Dollar" }
		];
	}

	private static readonly IEnumerable<Person> people = [];

	// Select gets a list of lists of phone numbers
	private static readonly IEnumerable<IEnumerable<PhoneNumber>> phoneLists =
		people.Select(p => p.PhoneNumbers!);

	// SelectMany flattens it to just a list of phone numbers.
	private static readonly IEnumerable<PhoneNumber>
		phoneNumbers = people.SelectMany(p => p.PhoneNumbers!);


	private static IEnumerable<object> GetFlattenedCollection(IEnumerable<Person> people)
	{
		var directory = people
		   .SelectMany(p => p.PhoneNumbers!,
					   (parent, child) => new { parent.Name, child.Number });
		return directory;
	}

	private static IEnumerable<Person[]> GetChunks(IEnumerable<Person> people)
	{
		var peopleCount = people.Count();
		if (peopleCount > 2) 
		{
			return people.Chunk(2);
		}
		return people.Chunk(1);
	}
}


// Types:

public class PhoneNumber
{
	public string? Number { get; set; }
}

public class Person
{
	public IEnumerable<PhoneNumber>? PhoneNumbers { get; set; }
	public string? Name { get; set; }
}
