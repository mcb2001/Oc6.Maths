using System;

namespace Oc6.Maths
{
    public static class ComplexMath
    {
        public static Complex Conjugate(Complex complex)
        {
            return new Complex
            {
                Real = complex.Real,
                Imaginary = -complex.Imaginary,
            };
        }

        public static double Length(Complex complex)
        {
            return Math.Sqrt((complex.Real * complex.Real) + (complex.Imaginary * complex.Imaginary));
        }

        public static Complex Round(Complex value, int digits = 0, MidpointRounding mode = MidpointRounding.AwayFromZero)
        {
            return new Complex
            {
                Real = Math.Round(value.Real, digits, mode),
                Imaginary = Math.Round(value.Imaginary, digits, mode)
            };
        }

        public static Complex Sqrt(Complex value)
        {
            if (value.Imaginary == 0)
            {
                return value.Real < 0
                    ? new Complex
                    {
                        Real = 0,
                        Imaginary = Math.Sqrt(-value.Real),
                    }
                    : new Complex
                    {
                        Real = Math.Sqrt(value.Real),
                        Imaginary = 0,
                    };
            }

            double a = value.Real;
            double b = value.Imaginary;

            double real = Math.Sqrt((a + Math.Sqrt((a * a) + (b * b))) / 2.0);
            double imaginary = Math.Sign(b) * Math.Sqrt((Math.Sqrt((a * a) + (b * b)) - a) / 2.0);

            return new Complex
            {
                Real = real,
                Imaginary = imaginary,
            };
        }

        public static Complex Root(Complex value, int root)
        {
            try
            {
                return NewtonRaphson.Iterate(x => Pow(x, root) - value, x => root * Pow(x, root - 1), rounding: null);
            }
            catch (IterationsExceededException<Complex> exc)
            {
                return exc.LastValue;
            }
        }

        public static Complex Pow(Complex value, int power)
        {
            Complex one = 1;

            if (power == 0)
            {
                return one;
            }
            else if (power < 0)
            {
                return one / Pow(value, -power);
            }
            else
            {
                Complex t = 1.0;

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
    }
}
