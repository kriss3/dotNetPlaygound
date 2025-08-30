using System;
using System.Collections.Concurrent;
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

	// Concurrent Dictionary
	public static async Task<ConcurrentDictionary<string, int>> BuildConcurrentDictionaryAsync(IEnumerable<string> keys) 
	{
		var result = new ConcurrentDictionary<string, int>();
		var tasks = keys.Select(async key =>
		{
			int computed = await Task.FromResult(key.Length); // Simulated async work
			result[key] = computed;
		});
		await Task.WhenAll(tasks);
		return result;
	}

	// 3. Using Array.Empty<T>() and Enumerable.Empty<T>()
	public static string[] GetEmptyArray() => [];

	public static IEnumerable<int> GetEmptyEnumerable() => [];

	// 4. C# 13 TryGetAlternateLookup (Simulated since this is future C#)
	public static bool TryAlternateLookup<T>(
		IEnumerable<T> items, 
		Func<T, string> keySelector, 
		string key, 
		out T? result)
	{
		result = items.FirstOrDefault(item => keySelector(item) == key);
		return result != null;
	}

	// 5. TrimExcess and pre-sized list
        public static List<int> CreateListAndTrim()
        {
            var list = new List<int>(1000);
            for (int i = 0; i < 1000; i++)
                list.Add(i);

            // Simulate cleanup
            list.RemoveRange(100, 900);
            list.TrimExcess(); // Reclaim memory
            return list;
        }
}
