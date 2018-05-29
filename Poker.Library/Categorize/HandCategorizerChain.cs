namespace Poker.Library.Categorize {
    internal class HandCategorizerChain {
        private HandCategorizerChain() {
            Head = new RoyalStraitFlushCategorizer();
            Head.RegisterNext(new StraightFlushCategorizer())
            .RegisterNext(new FourOfAKindCategorizer())
            .RegisterNext(new FullHouseCategorizer())
            .RegisterNext(new FlushCategorizer()) 
            .RegisterNext(new StraightCategorizer())
            .RegisterNext(new ThreeOfAKindCategorizer())
            .RegisterNext(new TwoPairCategorizer())
            .RegisterNext(new PairCategorizer())
            .RegisterNext(new HighCardCategorizer());
        }
        public static HandRanking GetRank(Hand hand) => _instance.Head.Categorize(hand);
        
        private HandCategorizer Head {get;}
        private static readonly HandCategorizerChain _instance = new HandCategorizerChain();
    }
}