using static System.Console;

namespace DecoratorPattern
{
    public class Sword : CharacterDecorator
    {
        private readonly int swordAddedImpactLevel = 50;
        /**
         * Constructs warrior with addition of a Sword decorator.
         * @param newCharacter as Character interface.
         */
        public Sword(ICharacter newCharacter) : base(newCharacter)
        {
            WriteLine("Adding Sword.");
        }
        /**
         * Returns the description of the Barbarian equipped with sword.
         * @return String with the Warrior description.
         */
        public override string GetDescription()
        {
            return tempCharacter.GetDescription() + ", Sword";
        }

        /**
         * Returns impact level for the Barbarian with sword.
         * @return int as impact level for the character.
         */
        public override int GetImpactLevel()
        {
            return tempCharacter.GetImpactLevel() + swordAddedImpactLevel;
        }
    }
}