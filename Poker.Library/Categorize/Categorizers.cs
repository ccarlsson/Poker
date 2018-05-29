using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (HasNoOfKind(2, hand))
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
            if (HasNoOfKind(3, hand))
                return HandRanking.ThreeOfAKind;
            return Next.Categorize(hand);
        }
    }

    class StraightCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (HasStrait(hand))
                return HandRanking.Strait;

            return Next.Categorize(hand);
        }
    }

    class FlushCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (HasFlush(hand))
                return HandRanking.Flush;
            return Next.Categorize(hand);
        }
    }

    class FullHouseCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (HasNoOfKind(3, hand) && HasNoOfKind(2, hand))
                return HandRanking.FullHouse;

            return Next.Categorize(hand);
        }
    }

    class FourOfAKindCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (HasNoOfKind(4, hand))
                return HandRanking.FourOfAKind;
            return Next.Categorize(hand);
        }
    }

    class StraightFlushCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (HasStrait(hand) && HasFlush(hand))
                return HandRanking.StraitFlush;
            return Next.Categorize(hand);
        }
    }

    class RoyalStraitFlushCategorizer : HandCategorizer
    {
        public override HandRanking Categorize(Hand hand)
        {
            if (HasFlush(hand) && HasStrait(hand) && hand.HighCard.Value == Value.Ace)
                return HandRanking.RoyalStraitFlush;
            return Next.Categorize(hand);
        }
    }
}
