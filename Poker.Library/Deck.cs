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
            var cards = new List<Card>(52);
            for (int s = 0; s < 4; s++)
                for (int v = 2; v < 15; v++)
                    cards.Add(new Card((Suit)s, (Value)v));
            _deck = new Stack<Card>(cards);
        }

        // Optimized Fisher-Yates shuffle in O(n) that preserves existing deterministic test behavior
        public void Shuffle()
        {
            var arr = _deck.ToArray(); // current order: top -> bottom
            for (int i = arr.Length - 1; i > 0; i--)
            {
                int j = i - _rnd.Next(i + 1);
                if (j != i)
                {
                    var tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
            }
            _deck = new Stack<Card>(arr); // enumerates arr in-order; new top becomes last element
        }
            
    }
}