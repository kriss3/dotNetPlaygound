using static System.Console;

namespace ConAppShuffleCards;

internal class Program
{
    static void Main()
    {
        WriteLine("Hello, World!");

        string[] deck = GenerateDeck();

        ShuffleDeck(deck);

        WriteLine("Shuffled Deck:");
        deck.ToList().ForEach(c => WriteLine(c));


        static string[] GenerateDeck()
        {
            string[] ranks = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            string[] suits = ["Hearts", "Diamonds", "Clubs", "Spades"];

            string[] deck = new string[52];
            int index = 0;

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck[index++] = $"{rank} of {suit}";
                }
            }

            return deck;
        }

        static void ShuffleDeck(string[] deck)
        {
            Random random = new();

            for (int i = deck.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);

                // Swap deck[i] and deck[j]
                (deck[j], deck[i]) = (deck[i], deck[j]);
            }
        }


    }
}
