using System;
using System.Globalization;

namespace Oc6.Maths
{
    public partial struct Complex : IEquatable<Complex>, IFormattable
    {
        public const string IMAGINARY_UNIT = "i";

        public double Real { get; set; }
        public double Imaginary { get; set; }

        private const string PLUS = "+";
        private const string MINUS = "-";
        private static readonly string I = IMAGINARY_UNIT.ToUpperInvariant();

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
            if (Complex.IsNaN(this))
            {
                return double.NaN.ToString();
            }

            if (Complex.IsNegativeInfinity(this))
            {
                return double.NegativeInfinity.ToString();
            }

            if (Complex.IsPositiveInfinity(this))
            {
                return double.PositiveInfinity.ToString();
            }

            if (Real == 0)
            {
                //imaginary
                return ImaginaryString(Imaginary.ToString(format, provider));
            }
            else if (Imaginary == 0)
            {
                return Real.ToString(format, provider);
            }
            else
            {
                string real = Real.ToString(format, provider);
                string imaginary = ImaginaryString(Imaginary.ToString(format, provider));

                if (Imaginary < 0)
                {
                    return $"{real}{imaginary}";
                }
                else
                {
                    return $"{real}{PLUS}{imaginary}";
                }
            }
        }

        private string ImaginaryString(string imaginary)
        {
            return $"{imaginary}{IMAGINARY_UNIT}";
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

        public static bool IsNaN(Complex complex)
        {
            return double.IsNaN(complex.Real) || double.IsNaN(complex.Imaginary);
        }

        public static bool IsInfinity(Complex complex)
        {
            return double.IsInfinity(complex.Real) || double.IsInfinity(complex.Imaginary);
        }

        public static bool IsPositiveInfinity(Complex complex)
        {
            return double.IsPositiveInfinity(complex.Real) || double.IsPositiveInfinity(complex.Imaginary);
        }

        public static bool IsNegativeInfinity(Complex complex)
        {
            return double.IsNegativeInfinity(complex.Real) || double.IsNegativeInfinity(complex.Imaginary);
        }

        public static Complex Parse(string s)
        {
            return Parse(s, NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo);
        }

        public static Complex Parse(string s, NumberStyles style)
        {
            return Parse(s, style, NumberFormatInfo.CurrentInfo);
        }

        public static Complex Parse(string s, IFormatProvider provider)
        {
            return Parse(s, NumberStyles.Float | NumberStyles.AllowThousands, provider);
        }

        public static Complex Parse(string s, NumberStyles style, IFormatProvider provider)
        {
            ComplexParts parts = Split(s);

            double real = parts.Real == null ? 0 : double.Parse(parts.Real, style, provider);
            double imaginary = parts.Imaginary == null ? 0 : double.Parse(parts.Imaginary, style, provider);

            return new Complex
            {
                Real = real,
                Imaginary = imaginary,
            };
        }

        public static bool TryParse(string s, out Complex complex)
        {
            return TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo, out complex);
        }

        public static bool TryParse(string s, NumberStyles style, out Complex complex)
        {
            return TryParse(s, style, NumberFormatInfo.CurrentInfo, out complex);
        }

        public static bool TryParse(string s, IFormatProvider provider, out Complex complex)
        {
            return TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, provider, out complex);
        }

        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out Complex complex)
        {
            ComplexParts parts = Split(s);

            double real = 0, imaginary = 0;

            if (parts.Real != null)
            {
                if (!double.TryParse(parts.Real, style, provider, out real))
                {
                    complex = default;
                    return false;
                }
            }

            if (parts.Imaginary != null)
            {
                if (!double.TryParse(parts.Imaginary, style, provider, out imaginary))
                {
                    complex = default;
                    return false;
                }
            }

            complex = new Complex
            {
                Real = real,
                Imaginary = imaginary,
            };

            return true;
        }

        private static ComplexParts SplitComplex(string s, string SIGN)
        {
            string[] parts = s.Split(SIGN.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return new ComplexParts
            {
                Real = parts[0].Trim(),
                Imaginary = parts[1].Replace(I, string.Empty).Trim(),
            };
        }

        private static ComplexParts Split(string s)
        {
            s = s.Trim().ToUpperInvariant();

            if (s.Contains(PLUS))
            {
                //complex
                return SplitComplex(s, PLUS);
            }
            else if (s.Contains(MINUS))
            {
                return SplitComplex(s, MINUS);
            }
            else
            {

                if (s.Contains(I))
                {
                    //imaginary

                    return new ComplexParts
                    {
                        Real = null,
                        Imaginary = s.Replace(I, string.Empty).Trim(),
                    };
                }
                else
                {
                    //real

                    return new ComplexParts
                    {
                        Real = s,
                        Imaginary = null,
                    };
                }
            }
        }

        private class ComplexParts
        {
            public string Real { get; set; }
            public string Imaginary { get; set; }
        }
    }
}
