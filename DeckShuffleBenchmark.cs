using BenchmarkDotNet.Attributes;
using Poker.Library;

namespace Poker.Benchmarks
{
    [MemoryDiagnoser]
    public class DeckShuffleBenchmark
    {
        private Deck _deck = null!;

        [IterationSetup]
        public void IterationSetup()
        {
            _deck = new Deck();
        }

        [Benchmark]
        public void Shuffle()
        {
            _deck.Shuffle();
        }
    }
}