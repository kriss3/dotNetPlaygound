using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConAppPlayingWithLambda.Model;

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
	public static IEnumerable<int> FilterCollection() 
	{
		return [];
	}

	//LINQ Project
	public static IEnumerable<int> ReshapeCollection()
	{
		return [];
	}

	//LINQ Order Collection members
	public static IEnumerable<int> OrderMemberCollection()
	{
		return [];
	}
}
