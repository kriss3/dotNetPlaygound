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

		var res = numberType switch
		{
			RandomNumberType.month => random.Next(1, 13), // 1..12
			RandomNumberType.dice  => Random.Shared.Next(1, 7),  // 1..6
			RandomNumberType.card  => Random.Shared.Next(0, 52), // 0..51
			_ => throw new ArgumentOutOfRangeException(nameof(numberType), numberType, "Unsupported number type.")

		};

		return result;
	}
}