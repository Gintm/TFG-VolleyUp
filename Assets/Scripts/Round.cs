using System;
using UnityEngine.Assertions;

namespace DefaultNamespace
{
    public class Round
    {
        readonly Questions questions;
        TimeSpan duration;
        
        public Round(Questions questionsOfTheCurrentRound)
        {
            TotalQuestions = questionsOfTheCurrentRound.HowMany;
            questions = questionsOfTheCurrentRound;
            
            duration = TimeSpan.Zero;
        }

        public int Fails { get; private set; }
        public int Hits { get; private set; }
        public int TotalQuestions { get; }
        public int Coins { get; private set; }

        public int RemainingQuestions => questions.HowMany;
        public bool HasEnded => RemainingQuestions == 0;

        public bool HasLost => Hits < TotalQuestions;

        public void Hit() => Hits++;

        public void Wrong() => Fails++;
        
        public void PassTime(TimeSpan someTime) => duration = duration.Add(someTime);

        public void EarnCoins() => Coins = Hits * 10;
        
        public Question PickNextQuestion() => questions.PickRandom();

        public ResultOfTheRound SealResult()
        {
            Assert.IsTrue(HasEnded);
            return new(duration, Hits.OutOf(TotalQuestions), Coins);
        }
    }
}