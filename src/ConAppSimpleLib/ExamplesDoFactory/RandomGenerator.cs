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

		var res = switch
		{
			// number between 1 .. 12
			numberType.month => random.Next(1, 13), 
			// number between 1 .. 6
			numberType.dice => random.Next(1, 7),
			numberType.card => random.Next(0, 52)
			_ => throw new ArgumentOutOfRangeException(nameof(numberType), "Unsupported number Type.");
			Rand
		};


		
		var month = random.Next(1, 13);

		
		var dice = random.Next(1, 7);

		// number between 0 .. 51
		var card = random.Next(52);

		return 0;
	}

}
