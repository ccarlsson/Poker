using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Library {
    public class Deck {
        private Stack<Card> _deck = new Stack<Card>();
        private IRandomizer _rnd;
        public int CardsLeft => _deck.Count;
        public Card Deal => _deck.Pop();

        public Deck() : this(new Randomizer()) { }
        public Deck(IRandomizer randomizer) {
            _rnd = randomizer;

            for(int i = 0; i < 4; i++) {
                for(int j = 0; j < 13; j++) {
                    _deck.Push(new Card((Suit)i, (Value)j+2));
                }
            }
        }

        public void Shuffle() {
            Stack<Card> newDeck = new Stack<Card>();
            List<Card> oldDeck = new List<Card>(_deck);
            while(oldDeck.Count > 0) {
                var tmpCard = oldDeck[_rnd.Next(oldDeck.Count)];
                newDeck.Push(tmpCard);
                oldDeck.Remove(tmpCard);
            } 
            _deck = newDeck;
        }
        
    }
}