using System;

namespace Poker.Library.Extensions {
   public static class SuitExtensions {
       public static string GetShortName(this Suit suit) =>
           suit switch
           {
               Suit.Clubs => "C",
               Suit.Hearts => "H",
               Suit.Spades => "S",
               Suit.Diamonds => "D",
               _ => throw new ArgumentException(nameof(suit))
           };

       public static string GetLongName(this Suit suit) => suit.ToString();
   }
}