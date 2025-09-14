using Xunit;

namespace Poker.Library.Tests
{
    public class CardShould
    {
        [Fact]
        public void Instanciate()
        {
            var c = new Card(Suit.Diamonds, Value.Ace);

            Assert.NotNull(c);
        }

        [Fact]
        public void Return_AD_if_AceOfDiamond()
        {
        //Given
            var c = new Card(Suit.Diamonds, Value.Ace);
        //When
            var result = c.ToString();
        //Then
            Assert.Equal("AD", result);
        }

        [Fact]
        public void Return_Ten_of_Spade()
        {
        //Given
            var c = new Card(Suit.Spades, Value.Ten);
            var expected = "Ten of Spades";
        //When
            var result = c.LongName;
        //Then
            Assert.Equal(expected, result);
        }
    }
}
