using System.Collections.Generic;
using System.Linq;

namespace ConAppDelegates;

public class MyCustomDelegates
{
	private readonly int[] numbers = [1, 2, 3, 4, 5, 6, 1000];
    
    public IEnumerable<int> GetBigNumbers() 
    {
        return numbers.Where(x => x > 1000);
    }
}

public record Person 
{
    public string FirstName { get; set; }
}
