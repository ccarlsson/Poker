using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Library {
    public class Deck {
        private Stack<Card> _deck;
        private readonly IRandomizer _rnd;
        public int CardsLeft => _deck.Count;
        public Card Deal => _deck.Pop();

        public Deck() : this(new Randomizer()) { }
        public Deck(IRandomizer randomizer) {
            _rnd = randomizer;
            var suits = Enumerable.Range(0, 4);
            var values = Enumerable.Range(2, 13); 

            var p = from s in suits
                    from v in values
                    select new Card((Suit)s, (Value)v);
            _deck = new Stack<Card>(p); 
        }

        public void Shuffle() =>
            _deck = new Stack<Card>(_deck.OrderBy(x => _rnd.Next()).Take(_deck.Count));
            
    }
}