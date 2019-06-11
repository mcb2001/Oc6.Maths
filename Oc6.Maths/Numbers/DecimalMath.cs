using Oc6.Maths.Util;
using System;

namespace Oc6.Maths.Numbers
{
    public static class DecimalMath
    {
        public const decimal PI = 3.141592653589793238462643383279M;
        public const decimal TAU = 6.283185307179586476925286766559M;

        public static decimal Pow(decimal value, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            else if (power < 0)
            {
                return 1.0M / Pow(value, -power);
            }
            else
            {
                decimal t = 1.0M;

                for (int i = 0; power > 0; ++i)
                {
                    if (power % 2 != 0)
                    {
                        t *= value;
                    }

                    power /= 2;

                    value *= value;
                }

                return t;
            }
        }

        public static decimal Sqrt(decimal value)
        {
            return Root(value, 2);
        }

        public static decimal Root(decimal value, int root)
        {
            if (IntegerMath.IsPowerOfTwo(root) && value < 0.0M)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "must be positive");
            }
            else if (value == 0.0M)
            {
                return 0.0M;
            }

            try
            {
                return NewtonRaphson.Iterate(x => Pow(x, root) - value, x => root * Pow(x, root - 1), rounding: null);
            }
            catch (IterationsExceededException<decimal> exc)
            {
                return exc.LastValue;
            }
        }

        public static decimal Sin(decimal angle)
        {
            decimal frac = angle;
            decimal sign = 1.0M;
            decimal sum = 0.0M;
            decimal at = 1.0M;

            while (frac != 0.0M)
            {
                sum += sign * frac;

                //next fraction
                frac *= angle;
                frac /= ++at;
                frac *= angle;
                frac /= ++at;

                //swap sign
                sign = -sign;
            }

            return Math.Max(-1.0M, Math.Min(1.0M, sum));
        }

        public static decimal Cos(decimal angle)
        {
            //cosine is just offset sine
            return DecimalMath.Sin((DecimalMath.PI / 2.0M) - angle);
        }

        public static decimal Tan(decimal angle)
        {
            decimal denominator = DecimalMath.Cos(angle);

            if (denominator == 0.0M)
            {
                throw new ArgumentOutOfRangeException(nameof(angle), $"Has to have a {nameof(DecimalMath.Cos)}({nameof(angle)}) not equal to 0");
            }
            else
            {
                //tangent is just sine over cosine
                decimal numerator = DecimalMath.Sin(angle);
                return numerator / denominator;
            }
        }
    }
}
