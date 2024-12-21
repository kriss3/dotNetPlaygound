using Cova.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppFunctional;
public class BindHelper
{
	Result<int, string> GetInitialResult() 
	{
		return SafeDivide(10, 2);
	}

	private static Result<int, string> SafeDivide(int numerator, int denominator)
	{
		return denominator == 0
			? Result.Failure<int, string>("")
			: Result.Success<int, string>(numerator / denominator);
	}

	private static Option<int> SaveDivide(int numerator, int denominator)
	{
		return denominator == 0
			? Option.None<int>()
			: Option.Some(numerator / denominator);
	}
}
