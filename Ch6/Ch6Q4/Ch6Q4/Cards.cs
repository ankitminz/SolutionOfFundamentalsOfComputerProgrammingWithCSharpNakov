// Write a program that prints all possible cards from a standard deck
// of cards, without jokers (there are 52 cards: 4 suits of 13 cards).

namespace Ch6Q4
{
    public static class Cards
    {
        public static void Main()
        {
            string[] suits = { "diamonds", "clubs", "hearts", "spades" };
            string[] cards = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven",
            "Eight", "Nine", "Ten", "Jack", "Queen", "King"};

            foreach(string card in cards)
            {
                foreach(string suit in suits)
                {
                    Console.WriteLine($"{card} of {suit}");
                }
            }
        }
    }
}