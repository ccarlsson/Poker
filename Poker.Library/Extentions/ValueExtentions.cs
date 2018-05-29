using System;


namespace Poker.Library.Extentions {
    public static class ValueExtentions {

        public static string GetLongName(this Value value) {
            return value.ToString();
        }

        public static string GetShortName(this Value value) {
            switch (value)
            {
                case Value.Two:
                case Value.Three:
                case Value.Four:
                case Value.Five:
                case Value.Six:
                case Value.Seven:
                case Value.Eight:
                case Value.Nine:
                case Value.Ten:
                    return ((int)value).ToString();
                case Value.Jack:
                    return "J";
                case Value.Queen:
                    return "Q";
                case Value.King:
                    return "K";
                case Value.Ace:
                    return "A";
                default:
                    throw new ArgumentException(nameof(value));
            } 
        }
    }
}