using static System.Console;

namespace DecoratorPattern;

public class Dagger : CharacterDecorator
{
    private readonly int daggerAddedImpactLevel = 10;

    public Dagger(ICharacter newCharacter) : base(newCharacter)
    {
        WriteLine("Making Barbarian");
        WriteLine("Adding Dagger");
    }

    public override string GetDescription()
    {
        return tempCharacter.GetDescription() + ", Dagger"; ;
    }

    public override int GetImpactLevel()
    {
        return tempCharacter.GetImpactLevel() + daggerAddedImpactLevel;
    }
}