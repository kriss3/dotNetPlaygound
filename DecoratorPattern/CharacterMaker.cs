using static System.Console;

namespace DecoratorPattern;
public class CharacterMaker 
{
	public static void Main() 
	{
		ICharacter barbarian = new Spear(new Sword(new Dagger(new BaseCharacter())));

		WriteLine("Character description: " + barbarian.GetDescription());
		WriteLine("Character Impact Level: " + barbarian.GetImpactLevel());
	}
}