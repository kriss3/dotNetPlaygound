
namespace DecoratorPattern
{
    public class BaseCharacter : ICharacter
    {
        private readonly int baseImpactLevel = 10;


        public string GetDescription()
        {
            return "Barbarian with a knife ";
        }

        public int GetImpactLevel()
        {
            return baseImpactLevel;
        }
    }
}