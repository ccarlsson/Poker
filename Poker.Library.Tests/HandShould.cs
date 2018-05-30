using Poker.Library.Categorize;
using System;
using Xunit;

namespace Poker.Library.Tests
{

    public class HandShould
    {
        [Fact]
        public void RankHighCard()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Club, Value.Three));
            hand.Add(new Card(Suit.Diamond, Value.Ace));
            hand.Add(new Card(Suit.Heart, Value.Jack));
            hand.Add(new Card(Suit.Spade, Value.Ten));
            hand.Add(new Card(Suit.Club, Value.Two));
            var expected = HandRanking.HighCard;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void RankPair()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Club, Value.Ace));
            hand.Add(new Card(Suit.Diamond, Value.Ace));
            hand.Add(new Card(Suit.Heart, Value.Jack));
            hand.Add(new Card(Suit.Spade, Value.Ten));
            hand.Add(new Card(Suit.Club, Value.Two));
            var expected = HandRanking.OnePair;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void RankTwoPairs()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Club, Value.Ace));
            hand.Add(new Card(Suit.Diamond, Value.Ace));
            hand.Add(new Card(Suit.Heart, Value.Jack));
            hand.Add(new Card(Suit.Spade, Value.Jack));
            hand.Add(new Card(Suit.Club, Value.Two));
            var expected = HandRanking.TwoPairs;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void RankThreeOfAKind()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Club, Value.Ace));
            hand.Add(new Card(Suit.Diamond, Value.Ace));
            hand.Add(new Card(Suit.Heart, Value.Ace));
            hand.Add(new Card(Suit.Spade, Value.Ten));
            hand.Add(new Card(Suit.Club, Value.Two));
            var expected = HandRanking.ThreeOfAKind;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void RankStrait()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Club, Value.Ace));
            hand.Add(new Card(Suit.Diamond, Value.King));
            hand.Add(new Card(Suit.Heart, Value.Jack));
            hand.Add(new Card(Suit.Spade, Value.Queen));
            hand.Add(new Card(Suit.Club, Value.Ten));
            var expected = HandRanking.Strait;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void RankStraitWithAceLow()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Club, Value.Ace));
            hand.Add(new Card(Suit.Diamond, Value.Two));
            hand.Add(new Card(Suit.Heart, Value.Three));
            hand.Add(new Card(Suit.Spade, Value.Four));
            hand.Add(new Card(Suit.Club, Value.Five));
            var expected = HandRanking.Strait;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void RankFlush()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Club, Value.Ace));
            hand.Add(new Card(Suit.Club, Value.Nine));
            hand.Add(new Card(Suit.Club, Value.Jack));
            hand.Add(new Card(Suit.Club, Value.Ten));
            hand.Add(new Card(Suit.Club, Value.Two));
            var expected = HandRanking.Flush;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void RankFullHouse()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Club, Value.Nine));
            hand.Add(new Card(Suit.Diamond, Value.Six));
            hand.Add(new Card(Suit.Heart, Value.Nine));
            hand.Add(new Card(Suit.Spade, Value.Nine));
            hand.Add(new Card(Suit.Club, Value.Six));
            var expected = HandRanking.FullHouse;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void RankFourOfAKind()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Club, Value.Ace));
            hand.Add(new Card(Suit.Diamond, Value.Ace));
            hand.Add(new Card(Suit.Heart, Value.Ace));
            hand.Add(new Card(Suit.Spade, Value.Ace));
            hand.Add(new Card(Suit.Club, Value.Two));
            var expected = HandRanking.FourOfAKind;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void RankStraightFlush()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Club, Value.Six));
            hand.Add(new Card(Suit.Club, Value.Five));
            hand.Add(new Card(Suit.Club, Value.Four));
            hand.Add(new Card(Suit.Club, Value.Three));
            hand.Add(new Card(Suit.Club, Value.Two));
            var expected = HandRanking.StraitFlush;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void RankStraightFlushWithAnAceLow()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Club, Value.Ace));
            hand.Add(new Card(Suit.Club, Value.Five));
            hand.Add(new Card(Suit.Club, Value.Four));
            hand.Add(new Card(Suit.Club, Value.Three));
            hand.Add(new Card(Suit.Club, Value.Two));
            var expected = HandRanking.StraitFlush;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void RankRoyalStraightFlush()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Heart, Value.Ace));
            hand.Add(new Card(Suit.Heart, Value.Jack));
            hand.Add(new Card(Suit.Heart, Value.King));
            hand.Add(new Card(Suit.Heart, Value.Ten));
            hand.Add(new Card(Suit.Heart, Value.Queen));
            var expected = HandRanking.RoyalStraitFlush;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void NotAcceptMoreThenFiveCards()
        {
            Hand hand = new Hand();
            hand.Add(new Card(Suit.Heart, Value.Two));
            hand.Add(new Card(Suit.Spade, Value.Ace));
            hand.Add(new Card(Suit.Heart, Value.Three));
            hand.Add(new Card(Suit.Diamond, Value.Nine));
            hand.Add(new Card(Suit.Heart, Value.Six));

            var ex = Assert.Throws<IndexOutOfRangeException>(() => hand.Add(new Card(Suit.Diamond, Value.Ace)));
            Assert.Equal("Cannot add more then five cards.", ex.Message);
        }
    }
}
