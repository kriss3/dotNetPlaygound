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



		// number between 1 .. 12
		var month = random.Next(1, 13);

		// number between 1 .. 6
		var dice = random.Next(1, 7);

		// number between 0 .. 51
		var card = random.Next(52);

		return 0;
	}

}
