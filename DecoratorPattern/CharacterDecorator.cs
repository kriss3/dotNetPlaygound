
using System.Runtime.InteropServices;

namespace DecoratorPattern;

public abstract class CharacterDecorator(ICharacter newCharacter) : ICharacter
{
    protected ICharacter tempCharacter = newCharacter;

    public virtual string GetDescription()
    {
        return tempCharacter.GetDescription();
    }

    public virtual int GetImpactLevel()
    {
        return tempCharacter.GetImpactLevel();
    }
}
