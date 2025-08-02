using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppModernDotNetTips.Library;
public static class PerformanceTips
{
	//Pre-sizing dictionary:
	public static Dictionary<string, string> CreatePresizedDictionary(IEnumerable<string> keys) 
	{
		var dict = new Dictionary<string, string>();
		foreach (var k in keys) 
		{
			dict[k] = $"The Value for {k}";
		}
		return dict;
	}
}
