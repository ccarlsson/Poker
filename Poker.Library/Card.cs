using System;
using Poker.Library.Extensions;

namespace Poker.Library
{
    public class Card
    {
        public Suit Suit { get; }
        public Value Value { get; }
        public Card(Suit suit, Value value) {
            Suit = suit;
            Value = value;
        }

        public string ShortName => this.ToString();

        public string LongName =>
             $"{Value.GetLongName()} of {Suit.GetLongName()}";


        public override string ToString(){
            return Value.GetShortName() + Suit.GetShortName();
        } 
    }
}
