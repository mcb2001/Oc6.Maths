namespace Oc6.Maths.Numbers
{
    public struct Fraction
    {
        public long Numerator { get; set; }
        public long Denominator { get; set; }

        public Fraction(long num, long den)
        {
            Numerator = num;
            Denominator = den;
        }

        public Fraction(byte num)
            : this(num, 1)
        {
        }

        public Fraction(sbyte num)
            : this(num, 1)
        {

        }

        public Fraction(long num)
            : this(num, 1)
        {
        }

        //Decimal to Fraction
        //Double to Fraction
    }
}
