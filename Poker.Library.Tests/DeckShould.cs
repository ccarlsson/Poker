using System;
using Poker.Library;
using Xunit;

namespace Poker.Library.Tests
{
    public class RandomizerStub : Poker.Library.IRandomizer {
        public int Next() {
            return 0;
        }

        public int Next(int maxValue) {
            return 0;
        }

        public int Next(int startValue, int maxValue) {
            return 0;
        }
    }
    public class DeckShould {

        [Fact]
        public void Deal2OfHearts()
        {
        //Given
            var deck = new Deck(new RandomizerStub());
            var expected = "2H";
            deck.Shuffle();
        //When
            var card = deck.Deal;
        //Then
            Assert.Equal(expected, card.ShortName);
        }
    }
}