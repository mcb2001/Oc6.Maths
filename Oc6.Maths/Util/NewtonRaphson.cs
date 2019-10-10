﻿using System;
using System.Numerics;

namespace Oc6.Maths.Util
{
    public static class NewtonRaphson
    {
        public const int DefaultIterations = 10000;
        public const int DefaultGuess = 1;
        public const int DefaultRounding = 14;

        public static Complex Iterate(Func<Complex, Complex> fx, Func<Complex, Complex> dydx, Complex? guess = null, int? iterations = DefaultIterations, int? rounding = DefaultRounding)
        {
            Complex x1 = guess ?? DefaultGuess, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (rounding.HasValue)
                {
                    x1 = new Complex(Math.Round(x1.Real, rounding.Value), Math.Round(x1.Imaginary, rounding.Value));
                }

                if (x0 == x1)
                {
                    return x0;
                }
            }

            throw new IterationsExceededException<Complex>(x1);
        }

        public static decimal Iterate(Func<decimal, decimal> fx, Func<decimal, decimal> dydx, decimal guess = DefaultGuess, int? iterations = DefaultIterations, int? rounding = DefaultRounding)
        {
            decimal x1 = guess, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (rounding.HasValue)
                {
                    x1 = Math.Round(x1, rounding.Value);
                }

                if (x0 == x1)
                {
                    return x0;
                }
            }

            throw new IterationsExceededException<decimal>(x1);
        }

        public static double Iterate(Func<double, double> fx, Func<double, double> dydx, double guess = DefaultGuess, int? iterations = DefaultIterations, int? rounding = DefaultRounding)
        {
            double x1 = guess, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (rounding.HasValue)
                {
                    x1 = Math.Round(x1, rounding.Value);
                }

                if (x0 == x1)
                {
                    return x0;
                }
            }

            throw new IterationsExceededException<double>(x1);
        }

        public static BigInteger Iterate(Func<BigInteger, BigInteger> fx, Func<BigInteger, BigInteger> dydx, BigInteger? guess = null, int? iterations = DefaultIterations)
        {
            BigInteger x1 = guess ?? 1, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (x0 == x1)
                {
                    return x0;
                }
            }

            throw new IterationsExceededException<BigInteger>(x1);
        }

        public static float Iterate(Func<float, float> fx, Func<float, float> dydx, float guess = DefaultGuess, int? iterations = DefaultIterations, int? rounding = DefaultRounding)
        {
            float x1 = guess, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (rounding.HasValue)
                {
                    x1 = (float)Math.Round(x1, rounding.Value);
                }

                if (x0 == x1)
                {
                    return x0;
                }
            }

            throw new IterationsExceededException<float>(x1);
        }

        public static int Iterate(Func<int, int> fx, Func<int, int> dydx, int guess = DefaultGuess, int? iterations = DefaultIterations)
        {
            int x1 = guess, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (x0 == x1)
                {
                    return x0;
                }
            }

            throw new IterationsExceededException<int>(x1);
        }

        public static long Iterate(Func<long, long> fx, Func<long, long> dydx, long guess = DefaultGuess, int? iterations = DefaultIterations)
        {
            long x1 = guess, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (x0 == x1)
                {
                    return x0;
                }
            }

            throw new IterationsExceededException<long>(x1);
        }
    }
}
