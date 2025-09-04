using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppSimpleLib.ExamplesDoFactory;

public class RandomGenerator 
{
	public enum RandomNumberType
	{
		month, dice, card
	}

	public static int GenerateNumber(RandomNumberType numberType)
	{
		Random random = new();

		var result = 0;

		return result;
	}
}