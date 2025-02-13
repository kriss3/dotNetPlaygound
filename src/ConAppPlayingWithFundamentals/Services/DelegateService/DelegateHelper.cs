using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace ConAppPlayingWithFundamentals.Services.DelegateService;
public static class DelegateHelper
{
	public static int MyDelegateFnct(int val1, int val2)
	{
		return val1 + val2;
	}

	//takes up to 16 params and MUST return a value
	public static void FuncDelegateExample()
	{
		Func<int, int, int> myResult = MyDelegateFnct;
		var res = myResult(5, 5);
		WriteLine($"Func can take 0 to 16 params and returns a value: {res}");
	}
}
