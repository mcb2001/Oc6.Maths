﻿using Oc6.Maths.Resources;
using Oc6.Maths.Util;
using System;

namespace Oc6.Maths.Numbers
{
    public static class DecimalMath
    {
        private static readonly decimal[] Factorials = new[] { 1M, 1M, 2M, 6M, 24M, 120M, 720M, 5040M, 40320M, 362880M, 3628800M, 39916800M, 479001600M, 6227020800M, 87178291200M, 1307674368000M, 20922789888000M, 355687428096000M, 6402373705728000M, 121645100408832000M, 2432902008176640000M, 51090942171709400000M, 1124000727777610000000M, 25852016738885000000000M, 620448401733239000000000M, 15511210043331000000000000M, 403291461126606000000000000M, 10888869450418400000000000000M, };

        public const decimal PI = 3.141592653589793238462643383279M;
        public const decimal TAU = 6.283185307179586476925286766559M;

        public static decimal Pow(decimal a, decimal b)
        {
            if (b == 0)
            {
                //base case
                return 1.0M;
            }
            else if (b < 0)
            {
                //less than 0 is just inverse
                return 1.0M / Pow(a, -b);
            }
            else if (b < long.MaxValue && b == Math.Round(b))
            {
                //if it's an integer power, use the fast version
                return Pow(a, (long)b);
            }
            else
            {
                //use the long version
                return Exp(Log(a) * b);
            }
        }

        private static decimal Pow(decimal a, long b)
        {
            decimal t = 1;

            for (int i = 0; b > 0; ++i)
            {
                if (b % 2 != 0)
                {
                    t *= a;
                    --b;
                }
                else
                {
                    a *= a;
                    b /= 2;
                }
            }

            return t;
        }

        public static decimal Exp(decimal a)
        {
            decimal x = a;
            int i = 1;
            decimal result = 1;
            decimal prev = 0;
            decimal num = 1;

            while (i < Factorials.Length && result != prev)
            {
                decimal den = Factorials[i];
                num *= x;

                decimal frac = num / den;
                result += frac;

                ++i;
            }

            return result;
        }

        public static decimal Log(decimal a)
        {
            decimal x = a - 1;
            decimal num = x;
            decimal den = 1;
            decimal result = x;
            decimal prev = a;
            decimal sign = 1.0M;

            while (result != prev)
            {
                ++den;
                prev = result;
                sign *= -1.0M;
                num *= x;
                decimal frac = (sign * num) / den;
                result += frac;
            }

            return result;
        }

        private static decimal Pow(decimal a, int b)
        {
            return Pow(a, (long)b);
        }

        public static decimal Sqrt(decimal value)
        {
            return Root(value, 2);
        }

        public static decimal Root(decimal value, int root)
        {
            if (IntegerMath.IsPowerOfTwo(root) && value < 0.0M)
            {
                throw new ArgumentOutOfRangeException(nameof(value), ErrorMessages.MustBePositive);
            }
            else if (value == 0.0M)
            {
                return 0.0M;
            }

            try
            {
                return NewtonRaphson.Iterate(x => Pow(x, (long)root) - value, x => root * Pow(x, (long)(root - 1)), rounding: null);
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
                throw new ArgumentOutOfRangeException(nameof(angle), ErrorMessages.NonZero);
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
