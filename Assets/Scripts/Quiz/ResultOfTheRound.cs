using System;

namespace DefaultNamespace
{
    public class ResultOfTheRound
    {
        public TimeSpan Duration { get; }

        public Fraction HitsProportion { get; }

        public int Coins { get; }

        public bool HasLost => HitsProportion.Quotient < 1;
        
        public ResultOfTheRound(TimeSpan duration, Fraction hitsProportion, int coins)
        {
            Duration = duration;
            HitsProportion = hitsProportion;
            Coins = coins;
        }
        
        public string HitsProp() => HitsProportion.ToString();
    }
}