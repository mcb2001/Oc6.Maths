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
            var expected = new Complex
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
            var expected = new Complex
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
            var expected = new Complex
            {
                Real = 18,
                Imaginary = -21.6,
            };

            Complex actual = A * B;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Divide()
        {
            var expected = new Complex
            {
                Real = 0.28901734104046245,
                Imaginary = 0.45472061657032758,
            };

            Complex actual = A / B;

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
            var c = new Complex
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
            var c = new Complex
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
            var expected = new Complex
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
            var expected = new Complex
            {
                Real = 3.0,
                Imaginary = 0.0,
            };

            Complex actual = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_Format_FormatProvider()
        {
            const string expected = "1,200.00 + 7,800.00i";
            const string format = "N";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            Complex c = A * 1000;
            string actual = c.ToString(format, provider);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetHashCode_Compare()
        {
            int a = A.GetHashCode();
            int b = B.GetHashCode();
            Assert.AreNotEqual(a, b);
        }
    }
}
