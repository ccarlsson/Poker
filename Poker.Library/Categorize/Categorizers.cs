using Poker.Library.Extentions;
using System.Linq;

namespace Poker.Library.Categorize
{
    class HighCardCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            return HandRanking.HighCard;
        }
    }

    class PairCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (hand.HasNoOfKind(2))
                return HandRanking.OnePair;
            return Next.Categorize(hand);
        }
    }

    class TwoPairCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            var p = hand.Cards.GroupBy(c => c.Value).Where(v => v.Count() == 2).Select(card => card);
            if (p.Count() == 2)
                return HandRanking.TwoPairs;

            return Next.Categorize(hand);
        }
    }

    class ThreeOfAKindCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (hand.HasNoOfKind(3))
                return HandRanking.ThreeOfAKind;
            return Next.Categorize(hand);
        }
    }
    
    class StraightCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (hand.HasStrait())
                return HandRanking.Strait;

            return Next.Categorize(hand);
        }
    }

    class FlushCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (hand.HasFlush())
                return HandRanking.Flush;
            return Next.Categorize(hand);
        }
    }

    class FullHouseCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (hand.HasNoOfKind(3) && hand.HasNoOfKind(2))
                return HandRanking.FullHouse;

            return Next.Categorize(hand);
        }
    }

    class FourOfAKindCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (hand.HasNoOfKind(4))
                return HandRanking.FourOfAKind;
            return Next.Categorize(hand);
        }
    }

    class StraightFlushCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (hand.HasStrait() && hand.HasFlush())
                return HandRanking.StraitFlush;
            return Next.Categorize(hand);
        }
    }

    class RoyalStraitFlushCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (hand.HasFlush() && hand.HasStrait() && hand.Has(Value.King) && hand.Has(Value.Ace))
                return HandRanking.RoyalStraitFlush;
            return Next.Categorize(hand);
        }
    }
}
