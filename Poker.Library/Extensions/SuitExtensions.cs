using System;

namespace Poker.Library.Extensions {
   public static class SuitExtensions {
       public static string GetShortName(this Suit suit) =>
           suit switch
           {
               Suit.Club => "C",
               Suit.Heart => "H",
               Suit.Spade => "S",
               Suit.Diamond => "D",
               _ => throw new ArgumentException(nameof(suit))
           };

       public static string GetLongName(this Suit suit) => suit.ToString();
   }
}