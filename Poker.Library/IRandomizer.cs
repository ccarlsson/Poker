namespace Poker.Library {
    public interface IRandomizer
    {
        int Next();   
        int Next(int startValue, int maxValue);
        int Next(int maxValue);
    }
}