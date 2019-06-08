using System;

namespace Oc6.Maths.Shared
{
    public static class NewtonRaphson
    {
        public const int DEFAULT_ITERATIONS = 10000;
        public const int DEFAULT_GUESS = 1;
        public const int DEFAULT_ROUNDING = 14;

        public static decimal Iterate(Func<decimal, decimal> fx, Func<decimal, decimal> dydx, decimal guess = DEFAULT_GUESS, int? iterations = DEFAULT_ITERATIONS, int? rounding = DEFAULT_ROUNDING)
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

        public static double Iterate(Func<double, double> fx, Func<double, double> dydx, double guess = DEFAULT_GUESS, int? iterations = DEFAULT_ITERATIONS, int? rounding = DEFAULT_ROUNDING)
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

        public static float Iterate(Func<float, float> fx, Func<float, float> dydx, float guess = DEFAULT_GUESS, int? iterations = DEFAULT_ITERATIONS, int? rounding = DEFAULT_ROUNDING)
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

        public static int Iterate(Func<int, int> fx, Func<int, int> dydx, int guess = DEFAULT_GUESS, int? iterations = DEFAULT_ITERATIONS)
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

        public static long Iterate(Func<long, long> fx, Func<long, long> dydx, long guess = DEFAULT_GUESS, int? iterations = DEFAULT_ITERATIONS)
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
