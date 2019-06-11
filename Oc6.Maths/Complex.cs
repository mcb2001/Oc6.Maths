using System;

namespace Oc6.Maths
{
    public partial struct Complex : IEquatable<Complex>, IFormattable
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex
            {
                Real = a.Real + b.Real,
                Imaginary = a.Imaginary + b.Imaginary,
            };
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex
            {
                Real = a.Real - b.Real,
                Imaginary = a.Imaginary - b.Imaginary,
            };
        }

        public static Complex operator *(Complex a, Complex b)
        {
            double x = a.Real;
            double y = a.Imaginary;
            double u = b.Real;
            double v = b.Imaginary;

            return new Complex
            {
                Real = (x * u) + (y * v),
                Imaginary = (x * v) + (y * u),
            };
        }

        public static Complex operator /(Complex a, Complex b)
        {
            double x = a.Real;
            double y = a.Imaginary;
            double u = b.Real;
            double v = b.Imaginary;

            return new Complex
            {
                Real = ((u * x) + (v * y)) / ((x * x) + (y * y)),
                Imaginary = ((v * x) - (u * y)) / ((x * x) + (y * y)),
            };
        }

        public static bool operator ==(Complex a, Complex b)
        {
            return a.Real == b.Real && a.Imaginary == b.Imaginary;
        }

        public static bool operator !=(Complex a, Complex b)
        {
            return a.Real != b.Real && a.Imaginary != b.Imaginary;
        }

        public static implicit operator Complex(byte d)
        {
            return new Complex
            {
                Real = d,
                Imaginary = 0,
            };
        }

        public static implicit operator Complex(sbyte d)
        {
            return new Complex
            {
                Real = d,
                Imaginary = 0,
            };
        }

        public static implicit operator Complex(short d)
        {
            return new Complex
            {
                Real = d,
                Imaginary = 0,
            };
        }

        public static implicit operator Complex(ushort d)
        {
            return new Complex
            {
                Real = d,
                Imaginary = 0,
            };
        }

        public static implicit operator Complex(int d)
        {
            return new Complex
            {
                Real = d,
                Imaginary = 0,
            };
        }

        public static implicit operator Complex(uint d)
        {
            return new Complex
            {
                Real = d,
                Imaginary = 0,
            };
        }

        public static implicit operator Complex(long d)
        {
            return new Complex
            {
                Real = d,
                Imaginary = 0,
            };
        }

        public static implicit operator Complex(ulong d)
        {
            return new Complex
            {
                Real = d,
                Imaginary = 0,
            };
        }

        public static implicit operator Complex(float d)
        {
            return new Complex
            {
                Real = d,
                Imaginary = 0,
            };
        }

        public static implicit operator Complex(double d)
        {
            return new Complex
            {
                Real = d,
                Imaginary = 0,
            };
        }

        public override string ToString()
        {
            return $"{Real.ToString()} + {Imaginary.ToString()}i";
        }

        public string ToString(string format)
        {
            return $"{Real.ToString(format)} + {Imaginary.ToString(format)}i";
        }

        public string ToString(IFormatProvider provider)
        {
            return $"{Real.ToString(provider)} + {Imaginary.ToString(provider)}i";
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return $"{Real.ToString(format, provider)} + {Imaginary.ToString(format, provider)}i";
        }

        public override bool Equals(object obj)
        {
            return obj is Complex complex ? Equals(complex) : false;
        }

        public bool Equals(Complex other)
        {
            return Real == other.Real && Imaginary == other.Imaginary;
        }

        public override int GetHashCode()
        {
            int hashCode = -837395861;
            hashCode = (hashCode * -1521134295) + Real.GetHashCode();
            hashCode = (hashCode * -1521134295) + Imaginary.GetHashCode();
            return hashCode;
        }
    }
}
