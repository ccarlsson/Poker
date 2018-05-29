using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker.Library.Extentions
{
    public static class HandExtentions
    {
        public static bool Has(this Hand hand, Value value)
        {
            foreach(var card in hand.Cards)
            {
                if (card.Value == value) return true;
            }
            return false;
        }

        public static bool HasNoOfKind(this Hand hand, int nr)
        {
            return hand.Cards.Select(c => c.Value).ToList().GroupBy(c => (int)c).Any(z => z.Count() == nr);
        }


        public static bool HasStrait(this Hand hand)
        {
            if (hand.Has(Value.Ace) && !hand.Has(Value.King))
                return TryLowStraight(hand);
   
            var values = hand.Cards.Select(c => c.Value).ToList();
            values.Sort();
            int expectedValue = (int)values[0];
            foreach (var value in values)
            {
                if ((int)value != expectedValue++)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool TryLowStraight(Hand hand)
        {
            return hand.Has(Value.Ace) &&
                hand.Has(Value.Two) &&
                hand.Has(Value.Three) &&
                hand.Has(Value.Four) &&
                hand.Has(Value.Five);
        }

        public static bool HasFlush(this Hand hand)
        {
            List<Suit> suits = hand.Cards.Select(c => c.Suit).ToList();
            var first = suits[0];
            foreach (var suit in suits)
            {
                if (suit != first)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
