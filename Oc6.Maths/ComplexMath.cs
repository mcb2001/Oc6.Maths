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
            return Root(value, 2);
        }

        public static Complex Root(Complex value, int root)
        {
            try
            {
                return NewtonRaphson.Iterate(x => Pow(x, root) - value, x => root * Pow(x, root - 1), rounding: null);
            }
            catch (IterationsExceededException<double> exc)
            {
                return exc.LastValue;
            }
        }

        public static Complex Pow(Complex value, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            else if (power < 0)
            {
                return 1.0 / Pow(value, -power);
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
