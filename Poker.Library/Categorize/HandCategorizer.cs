using System.Collections.Generic;
using System.Linq;


namespace Poker.Library.Categorize {
    abstract class HandCategorizer {
        protected HandCategorizer Next { get; private set;} 

        public HandCategorizer RegisterNext(HandCategorizer next) {
            Next = next;
            return Next;
        }

        public abstract HandRanking Categorize(Hand hand);

        protected static bool HasNoOfKind(int n, Hand hand) {
            return hand.Cards.Select(c => c.Value).ToList().GroupBy(c => (int)c).Any(z => z.Count() == n);
        }

        protected static bool HasStrait(Hand hand) {
            var values = hand.Cards.Select(c => c.Value).ToList();
            values.Sort();
            int expectedValue = (int)values[0];
            foreach (var value in values)
            {
                if((int)value != expectedValue++) {
                    return false;
                }
            }
            return true;
        }

        protected static bool HasFlush(Hand hand) {
            List<Suit> suits = hand.Cards.Select(c => c.Suit).ToList();
            var first = suits[0];
            foreach (var suit in suits)
            {
                if(suit != first) {
                    return false;
                }
            }
            return true;
        }
    }
}