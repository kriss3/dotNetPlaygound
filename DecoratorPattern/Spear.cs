using static System.Console;

namespace DecoratorPattern
{

    public class Spear : CharacterDecorator
    {
        private int spearAddedImpactLevel = 50;

        public Spear(ICharacter newCharacter) : base(newCharacter)
        {
            WriteLine("Adding Spear");
        }

        public string GetDescription()
        {
            throw new System.NotImplementedException();
        }

        public int GetImpactLevel()
        {
            throw new System.NotImplementedException();
        }
    }
}