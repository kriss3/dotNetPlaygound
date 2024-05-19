namespace DecoratorPattern;

public abstract class CharacterDecorator : ICharacter
{
    protected ICharacter tempCharacter;

    public CharacterDecorator(ICharacter newCharacter)
    {
        //start customizing our Character
        tempCharacter = newCharacter;
    }

    public virtual string GetDescription()
    {
        return tempCharacter.GetDescription();
    }

    public virtual int GetImpactLevel()
    {
        return tempCharacter.GetImpactLevel();
    }
}
