using System.Linq;

namespace Poker.Library.Extentions
{
    public static class HandExtentions
    {
        public static bool Has(this Hand hand, Value value) =>
            hand.Cards.Any(c => c.Value == value);

        public static bool HasNoOfKind(this Hand hand, int nr) =>
            hand.Cards.Select(c => c.Value).ToList().GroupBy(c => (int)c).Any(z => z.Count() == nr);

        public static bool HasFlush(this Hand hand) =>
            hand.Cards.All(c => c.Suit == hand.Cards.First().Suit);

        public static bool HasStrait(this Hand hand)
        {
            // Annoyingly need to catch straits that starts with an ace. 
            if (hand.Has(Value.Ace) && !hand.Has(Value.King))
                return TryLowStraight(hand);
            
            return hand.Cards
                .Select(c => (int)c.Value)
                .OrderBy(c => c)
                .Zip(Enumerable.Range(hand.Cards.Select(c => (int)c.Value).OrderBy(c => c).First(), 5), (a, e) => a == e)
                .All(r => (r == true));
        }

        private static bool TryLowStraight(Hand hand)
        {
            return hand.Has(Value.Ace) &&
                hand.Has(Value.Two) &&
                hand.Has(Value.Three) &&
                hand.Has(Value.Four) &&
                hand.Has(Value.Five);
        } 
    }
}
