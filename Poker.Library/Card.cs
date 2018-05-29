using System;
using Poker.Library.Extentions;

namespace Poker.Library
{
    public class Card
    {
        public Suit Suit { get; }
        public Value Value { get; }
       
        private Value _value;
        public Card(Suit suit, Value value) {
            Suit = suit;
            Value = value;
        }

        public string GetCard() {
            return this.ToString();
        }

        public string GetLongName()  =>
             $"{Value.GetLongName()} of {Suit.GetLongName()}";
        

        public override string ToString(){
            return Value.GetShortName() + Suit.GetShortName();
        } 
    }
}
