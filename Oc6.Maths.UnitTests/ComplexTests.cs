using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class ComplexTests
    {
        private static readonly Complex A = new Complex
        {
            Real = 1.2,
            Imaginary = 7.8,
        };

        private static readonly Complex B = new Complex
        {
            Real = -3.2,
            Imaginary = 2.8,
        };

        [TestMethod]
        public void Add()
        {
            Complex expected = new Complex
            {
                Real = -2,
                Imaginary = 10.6,
            };

            Complex actual = A + B;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Subtract()
        {
            Complex expected = new Complex
            {
                Real = 4.4,
                Imaginary = 5,
            };

            Complex actual = A - B;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiply()
        {
            Complex expected = new Complex
            {
                Real = -25.68,
                Imaginary = -21.6,
            };

            Complex actual = A * B;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Square()
        {
            Complex expected = new Complex
            {
                Real = -1,
                Imaginary = 0,
            };

            Complex actual = new Complex
            {
                Real = 0,
                Imaginary = 1,
            };

            actual *= actual;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FromPolar()
        {
            Complex expected = new Complex
            {
                Real = 2.5,
                Imaginary = 6.25,
            };

            PolarComplex polar = new PolarComplex
            {
                Argument = 1.1902899496825317,
                Modulus = 6.73145600891813,
            };

            Complex actual = Complex.FromPolar(polar);
            actual = ComplexMath.Round(actual, 5); // is actually: 2.5000000000000004+6.25i
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Divide0()
        {
            Complex expected = new Complex
            {
                Real = 0.99557522123893794,
                Imaginary = -1.566371681415929,
            };

            Complex actual = A / B;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Divide1()
        {
            Complex expected = new Complex
            {
                Real = 9.0 / 58.0,
                Imaginary = 37.0 / 58.0,
            };

            Complex a = new Complex
            {
                Real = 3.0,
                Imaginary = 4.0,
            };

            Complex b = new Complex
            {
                Real = 7.0,
                Imaginary = -3.0,
            };

            Complex actual = a / b;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotEqual()
        {
            Assert.IsFalse(A.Equals(B));
        }

        [TestMethod]
        public void Equal()
        {
            Complex c = new Complex
            {
                Real = 1.2,
                Imaginary = 7.8,
            };

            Assert.IsTrue(A.Equals(c));
        }

        [TestMethod]
        public void EqualSelf()
        {
            Assert.IsTrue(A.Equals(A));
            Assert.IsTrue(B.Equals(B));
        }

        [TestMethod]
        public void NotEqualObject()
        {
            object obj = new object();
            Assert.IsFalse(A.Equals(obj));
        }

        [TestMethod]
        public void EqualTo()
        {
            Complex c = new Complex
            {
                Real = 1.2,
                Imaginary = 7.8,
            };

            Assert.IsTrue(A == c);
        }

        [TestMethod]
        public void NotEqualTo()
        {
            Assert.IsTrue(A != B);
        }

        [TestMethod]
        public void Implicit_float()
        {
            Complex expected = new Complex
            {
                Real = 3.0,
                Imaginary = 0.0,
            };

            Complex actual = 3.0F;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Implicit_int()
        {
            Complex expected = new Complex
            {
                Real = 3.0,
                Imaginary = 0.0,
            };

            Complex actual = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_Format_FormatProvider_Positive()
        {
            const string expected = "1,200.00+7,800.00i";
            const string format = "N";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Complex c = A * 1000;
            string actual = c.ToString(format, provider);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_Format_FormatProvider_Negative()
        {
            const string expected = "1,200.00-7,800.00i";
            const string format = "N";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Complex c = new Complex
            {
                Real = 1200,
                Imaginary = -7800,
            };
            string actual = c.ToString(format, provider);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_NaN()
        {
            const string expected = "NaN";
            Complex c = new Complex
            {
                Real = double.NaN,
                Imaginary = 1,
            };
            string actual = c.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_PositiveInfinity()
        {
            const string expected = "∞";
            Complex c = new Complex
            {
                Real = 1,
                Imaginary = double.PositiveInfinity,
            };
            string actual = c.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_NegativeInfinity()
        {
            const string expected = "-∞";
            Complex c = new Complex
            {
                Real = 1,
                Imaginary = double.NegativeInfinity,
            };
            string actual = c.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetHashCode_Compare()
        {
            int a = A.GetHashCode();
            int b = B.GetHashCode();
            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void Parse_Real()
        {
            Complex expected = new Complex
            {
                Real = 1234.56789101112,
                Imaginary = 0,
            };

            Complex actual = Complex.Parse(expected.ToString());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_Imaginary()
        {
            Complex expected = new Complex
            {
                Real = 0,
                Imaginary = 1234.56789101112,
            };

            Complex actual = Complex.Parse(expected.ToString());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse()
        {
            Complex expected = new Complex
            {
                Real = -1234.56789101112,
                Imaginary = 1234.56789101112,
            };

            Complex actual = Complex.Parse(expected.ToString());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryParse_Real()
        {
            Complex expected = new Complex
            {
                Real = 1234.56789101112,
                Imaginary = 0,
            };

            Assert.IsTrue(Complex.TryParse(expected.ToString(), out Complex actual));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryParse_Imaginary()
        {
            Complex expected = new Complex
            {
                Real = 0,
                Imaginary = 1234.56789101112,
            };

            Assert.IsTrue(Complex.TryParse(expected.ToString(), out Complex actual));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryParse()
        {
            Complex expected = new Complex
            {
                Real = -1234.56789101112,
                Imaginary = 1234.56789101112,
            };

            Assert.IsTrue(Complex.TryParse(expected.ToString(), out Complex actual));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryParse_False()
        {
            Complex expected = default;
            Assert.IsFalse(Complex.TryParse("NOT_A_COMPLEX_NUMBER", out Complex actual));
            Assert.AreEqual(expected, actual);
        }
    }
}
