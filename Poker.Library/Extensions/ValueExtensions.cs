using System;

namespace Poker.Library.Extensions {
    public static class ValueExtensions {

        public static string GetLongName(this Value value) => value.ToString();

        public static string GetShortName(this Value value) =>
            value switch
            {
                Value.Jack => "J",
                Value.Queen => "Q",
                Value.King => "K",
                Value.Ace => "A",
                _ when (int)value >= 2 && (int)value <= 10 => ((int)value).ToString(),
                _ => throw new ArgumentException("Invalid value.", nameof(value))
            };
    }
}