using System.Linq;

namespace Poker.Library.Extensions
{
    public static class HandExtensions
    {
        public static bool Has(this Hand hand, Value value) =>
            hand.Cards.Any(c => c.Value == value);

        public static bool HasNoOfKind(this Hand hand, int nr) =>
            hand.Cards
                .Select(c => c.Value)
                .GroupBy(v => v)
                .Any(g => g.Count() == nr);

        public static bool HasFlush(this Hand hand)
        {
            var firstSuit = hand.Cards.First().Suit;
            return hand.Cards.All(c => c.Suit == firstSuit);
        }

        public static bool HasStraight(this Hand hand)
        {
            var values = hand.Cards
                .Select(c => (int)c.Value)
                .OrderBy(v => v)
                .ToArray();

            // must be 5 distinct ranks
            if (values.Distinct().Count() != 5) return false;

            // Ace-low straight (A=14 treated as 1): 2,3,4,5,14
            if (values.SequenceEqual(new[] { 2, 3, 4, 5, 14 })) return true;

            // regular straight: v[i] == v[0] + i
            var start = values[0];
            for (int i = 1; i < 5; i++)
                if (values[i] != start + i) return false;

            return true;
        }
    }
}
