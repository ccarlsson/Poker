using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poker.Library.Categorize;

namespace Poker.Library {
    public class Hand {
        private readonly List<Card> _cards = new List<Card>();
        public HandRanking Rank { get; private set; } = HandRanking.Unknown;

        public void Add(Card card) {
            if (_cards.Count >= 5) throw new IndexOutOfRangeException("Cannot add more then five cards.");

            _cards.Add(card);

            if (_cards.Count == 5) {
                Rank = HandCategorizerChain.GetRank(this);
            }
        }

        public Card HighCard {
            get {
                if (_cards.Count == 0) throw new IndexOutOfRangeException("Empty hand");
                return _cards.MaxBy(c => c.Value)!;
            }
        }

        public IEnumerable<Card> Cards => _cards;

        public override string ToString() => string.Join(" ", _cards);
    }
}