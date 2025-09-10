using Cova.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppSimpleLib.ExamplesDoFactory;
public static class OptionDemo
{
	// Returns Some(n) when input is a positive int; otherwise None<int>()
	public static Option<int> TryParsePositiveInt(string input) 
	{
		var x = int.TryParse(input, out int result) && result > 0
			? Option.Some(result) : Option.None<int>();
		return x;
	}

	// Example of getting an environment variable as Option<string>
	public static Option<string> TryGetEnv(string variable) 
	{
		throw new NotImplementedException();
	}
}
