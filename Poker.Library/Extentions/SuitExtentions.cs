using System;


namespace Poker.Library.Extentions {
   public static class SuitExtentions {
       public static string GetShortName(this Suit suit) {
           switch (suit)
            {
                case Suit.Club:
                    return "C";
                case Suit.Heart:
                    return "H";
                case Suit.Spade:
                    return "S";
                case Suit.Diamond:
                    return "D";
                default:
                    throw new ArgumentException(nameof(suit));
            }
       }

       public static string GetLongName(this Suit suit) {
           return suit.ToString();
       }
   }
}