using System;

namespace DefaultNamespace
{
    public class ResultOfTheRound
    {
        public TimeSpan Duration { get; }
        public Fraction HitsProportion { get; }
        public bool HasLost => HitsProportion.Quotient < 1;
        
        public ResultOfTheRound(TimeSpan duration, Fraction hitsProportion)
        {
            Duration = duration;
            HitsProportion = hitsProportion;
        }
        
        public string HitsProp() => HitsProportion.ToString();
    }
}