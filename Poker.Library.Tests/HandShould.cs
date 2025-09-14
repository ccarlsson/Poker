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
            hand.Add(new Card(Suit.Clubs, Value.Three));
            hand.Add(new Card(Suit.Diamonds, Value.Ace));
            hand.Add(new Card(Suit.Hearts, Value.Jack));
            hand.Add(new Card(Suit.Spades, Value.Ten));
            hand.Add(new Card(Suit.Clubs, Value.Two));
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
            hand.Add(new Card(Suit.Clubs, Value.Ace));
            hand.Add(new Card(Suit.Diamonds, Value.Ace));
            hand.Add(new Card(Suit.Hearts, Value.Jack));
            hand.Add(new Card(Suit.Spades, Value.Ten));
            hand.Add(new Card(Suit.Clubs, Value.Two));
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
            hand.Add(new Card(Suit.Clubs, Value.Ace));
            hand.Add(new Card(Suit.Diamonds, Value.Ace));
            hand.Add(new Card(Suit.Hearts, Value.Jack));
            hand.Add(new Card(Suit.Spades, Value.Jack));
            hand.Add(new Card(Suit.Clubs, Value.Two));
            var expected = HandRanking.TwoPairs;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual); 
        }

        [Fact]
        public void RankStraight()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Clubs, Value.Ace));
            hand.Add(new Card(Suit.Diamonds, Value.King));
            hand.Add(new Card(Suit.Hearts, Value.Jack));
            hand.Add(new Card(Suit.Spades, Value.Queen));
            hand.Add(new Card(Suit.Clubs, Value.Ten));
            var expected = HandRanking.Straight;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual); 
        }

        [Fact]
        public void RankStraightWithAceLow()
        {
            //Given
            var hand = new Hand();
            hand.Add(new Card(Suit.Clubs, Value.Ace));
            hand.Add(new Card(Suit.Diamonds, Value.Two));
            hand.Add(new Card(Suit.Hearts, Value.Three));
            hand.Add(new Card(Suit.Spades, Value.Four));
            hand.Add(new Card(Suit.Clubs, Value.Five));
            var expected = HandRanking.Straight;
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
            hand.Add(new Card(Suit.Clubs, Value.Ace));
            hand.Add(new Card(Suit.Clubs, Value.Nine));
            hand.Add(new Card(Suit.Clubs, Value.Jack));
            hand.Add(new Card(Suit.Clubs, Value.Ten));
            hand.Add(new Card(Suit.Clubs, Value.Two));
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
            hand.Add(new Card(Suit.Clubs, Value.Nine));
            hand.Add(new Card(Suit.Diamonds, Value.Six));
            hand.Add(new Card(Suit.Hearts, Value.Nine));
            hand.Add(new Card(Suit.Spades, Value.Nine));
            hand.Add(new Card(Suit.Clubs, Value.Six));
            var expected = HandRanking.FullHouse;
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
            hand.Add(new Card(Suit.Clubs, Value.Six));
            hand.Add(new Card(Suit.Clubs, Value.Five));
            hand.Add(new Card(Suit.Clubs, Value.Four));
            hand.Add(new Card(Suit.Clubs, Value.Three));
            hand.Add(new Card(Suit.Clubs, Value.Two));
            var expected = HandRanking.StraightFlush;
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
            hand.Add(new Card(Suit.Clubs, Value.Ace));
            hand.Add(new Card(Suit.Clubs, Value.Five));
            hand.Add(new Card(Suit.Clubs, Value.Four));
            hand.Add(new Card(Suit.Clubs, Value.Three));
            hand.Add(new Card(Suit.Clubs, Value.Two));
            var expected = HandRanking.StraightFlush;
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
            hand.Add(new Card(Suit.Hearts, Value.Ace));
            hand.Add(new Card(Suit.Hearts, Value.Jack));
            hand.Add(new Card(Suit.Hearts, Value.King));
            hand.Add(new Card(Suit.Hearts, Value.Ten));
            hand.Add(new Card(Suit.Hearts, Value.Queen));
            var expected = HandRanking.RoyalStraightFlush;
            //When
            var actual = hand.Rank;
            //Then
            Assert.Equal(expected, actual); 
        }

        [Fact]
        public void NotAcceptMoreThenFiveCards()
        {
            Hand hand = new Hand();
            hand.Add(new Card(Suit.Hearts, Value.Two));
            hand.Add(new Card(Suit.Spades, Value.Ace));
            hand.Add(new Card(Suit.Hearts, Value.Three));
            hand.Add(new Card(Suit.Diamonds, Value.Nine));
            hand.Add(new Card(Suit.Hearts, Value.Six));

            var ex = Assert.Throws<IndexOutOfRangeException>(() => hand.Add(new Card(Suit.Diamonds, Value.Ace)));
            Assert.Equal("Cannot add more then five cards.", ex.Message);
        }

        [Fact]
        public void ReturnCorrectString()
        {
            Hand hand = new Hand();
            hand.Add(new Card(Suit.Hearts, Value.Ace));
            hand.Add(new Card(Suit.Hearts, Value.Jack));
            hand.Add(new Card(Suit.Hearts, Value.King));
            hand.Add(new Card(Suit.Hearts, Value.Ten));
            hand.Add(new Card(Suit.Hearts, Value.Queen));
            var expected = "AH JH KH 10H QH";

            var actual = hand.ToString();

            Assert.Equal(expected, actual);
        }
    }
}
