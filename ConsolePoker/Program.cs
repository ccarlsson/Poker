using System;
using Poker.Library;

namespace ConsolePoker
{
    class Program
    {
        static Deck deck;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to poker deal!");

            deck = new Deck();
            deck.Shuffle();

            while (deck.CardsLeft > 10) 
            {
                Console.WriteLine($"Cards left in the deck: {deck.CardsLeft}");
                Hand hand = new Hand();
                for (int i = 0; i < 5; i++)
                {
                    hand.Add(deck.Deal);   
                }

                PrintHand(hand);
                


            }


            Console.ReadLine();
        }

        private static void PrintHand(Hand hand)
        {
            ConsoleColor tmp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine($"You got {hand.Rank}");
            Console.ForegroundColor = tmp;
            Console.WriteLine($"Cards are: {hand}");
        }
    }
}
