using JetBrains.Annotations;

namespace DefaultNamespace
{
    public struct Fraction
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public float Quotient => (float)Numerator / Denominator;
        
        public Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }
        
        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }

        public string ToPercentage()
        {
            return (float)Numerator / Denominator * 100 + "%";
        }
        
        public static Fraction operator ++(Fraction fraction)
        {
            return new Fraction(fraction.Numerator + 1, fraction.Denominator);
        }
    }

    public static class FractionCtor
    {
        [Pure] public static Fraction OutOf(this int numerator, int denominator)
            => new Fraction(numerator, denominator);
    }
}