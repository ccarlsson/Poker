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


       
    }
}