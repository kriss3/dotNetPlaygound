using static System.Console;

namespace DecoratorPattern;


public class Spear : CharacterDecorator
{
    private readonly int spearAddedImpactLevel = 50;

    public Spear(ICharacter newCharacter) : base(newCharacter)
    {
        WriteLine("Adding Spear");
    }

    public override string GetDescription()
    {
        return tempCharacter.GetDescription() + ", Spear";
    }

    public override int GetImpactLevel()
    {
        return tempCharacter.GetImpactLevel() + spearAddedImpactLevel;
    }
}