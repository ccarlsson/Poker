using System;
using System.Linq;
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



    public class DeckShould
    {

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


        [Fact]
        public void Have47CardsAfterDealingAHand()
        {
            var deck = new Deck(new RandomizerStub());
            var expected = 47;

            var p = Enumerable.Range(0, 5).Select(x => deck.Deal).ToList();

            var actual = deck.CardsLeft;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Have52Cards()
        {
            var deck = new Deck(new RandomizerStub());
            var expected = 52;

            var actual = deck.CardsLeft;
            Assert.Equal(expected, actual);
        }
    }
}