using System;

namespace Problem_2.Fraction_Calculator
{
    public struct Fraction
    {
        private double numerator;
        private double denominator;
        public Fraction(double numerator, double denominator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public double Numerator { get; private set; }

        public double Denominator
        {
            get { return this.denominator; }
            private set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator can not be zero!");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction firstFraction, Fraction secondFraction)
        {
            //return new Fraction(firstFraction.Numerator*secondFraction.Numerator, firstFraction.Denominator*secondFraction.Denominator);
            firstFraction.Numerator *= secondFraction.Denominator;
            secondFraction.Numerator *= firstFraction.Denominator;
            double commonDenom = firstFraction.Denominator * secondFraction.Denominator;

            return new Fraction(firstFraction.Numerator + secondFraction.Numerator, commonDenom);
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Numerator/this.Denominator);
        }
    }
}
