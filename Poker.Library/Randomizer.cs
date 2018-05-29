using System;

namespace Poker.Library {
    public class Randomizer : IRandomizer {

        private Random _rnd = new Random();

        public int Next() => _rnd.Next();
        public int Next(int startValue, int maxValue) => _rnd.Next(startValue, maxValue);
        public int Next(int maxValue) => _rnd.Next(maxValue);
    }
}