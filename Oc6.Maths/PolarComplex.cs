using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Oc6.Maths
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct PolarComplex : IEquatable<PolarComplex>, IFormattable
    {
        public double Argument { get; set; }
        public double Modulus { get; set; }

        public static explicit operator PolarComplex(Complex complex)
        {
            return FromComplex(complex);
        }

        public static PolarComplex FromComplex(Complex complex)
        {
            double modulus = ComplexMath.Length(complex);
            double argument = GetArgument(complex.Real, complex.Imaginary, modulus);

            return new PolarComplex
            {
                Argument = argument,
                Modulus = modulus,
            };
        }

        private static double GetArgument(double x, double y, double r)
        {
            if (r == 0)
            {
                return double.NaN;
            }
            else if (y >= 0)
            {
                return Math.Acos(x / r);
            }
            else
            {
                return -Math.Acos(x / r);
            }
        }

        public static bool operator ==(PolarComplex a, PolarComplex b)
        {
            return a.Argument == b.Argument && a.Modulus == b.Modulus;
        }

        public static bool operator !=(PolarComplex a, PolarComplex b)
        {
            return a.Argument != b.Argument && a.Modulus != b.Modulus;
        }

        public override string ToString()
        {
            return ToString(null, NumberFormatInfo.CurrentInfo);
        }

        public string ToString(string format)
        {
            return ToString(format, NumberFormatInfo.CurrentInfo);
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString(null, provider);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (PolarComplex.IsNaN(this))
            {
                return double.NaN.ToString();
            }

            if (PolarComplex.IsNegativeInfinity(this))
            {
                return double.NegativeInfinity.ToString();
            }

            if (PolarComplex.IsPositiveInfinity(this))
            {
                return double.PositiveInfinity.ToString();
            }

            return $"{Argument.ToString(format, provider)};{Modulus.ToString(format, provider)}";
        }

        public static bool IsNaN(PolarComplex complex)
        {
            return double.IsNaN(complex.Argument) || double.IsNaN(complex.Modulus);
        }

        public static bool IsInfinity(PolarComplex complex)
        {
            return double.IsInfinity(complex.Argument) || double.IsInfinity(complex.Modulus);
        }

        public static bool IsPositiveInfinity(PolarComplex complex)
        {
            return double.IsPositiveInfinity(complex.Argument) || double.IsPositiveInfinity(complex.Modulus);
        }

        public static bool IsNegativeInfinity(PolarComplex complex)
        {
            return double.IsNegativeInfinity(complex.Argument) || double.IsNegativeInfinity(complex.Modulus);
        }

        public override bool Equals(object obj)
        {
            return obj is PolarComplex complex && Equals(complex);
        }

        public bool Equals(PolarComplex other)
        {
            return Argument == other.Argument && Modulus == other.Modulus;
        }

        public override int GetHashCode()
        {
            int hashCode = 2107890816;
            hashCode = hashCode * -1521134295 + Argument.GetHashCode();
            hashCode = hashCode * -1521134295 + Modulus.GetHashCode();
            return hashCode;
        }
    }
}
