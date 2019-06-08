using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Decimal;
using System;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public sealed class DecimalMathsTests
    {
        [TestMethod]
        public void Pow()
        {
            const decimal expected = 81.0M;
            decimal actual = 9.0M;
            actual = DecimalMath.Pow(actual, 2);
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Sqrt()
        {
            const decimal expected = 9.0M;
            decimal actual = 81.0M;
            actual = DecimalMath.Sqrt(actual);
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Cos_Zero()
        {
            decimal expected = 0.0M;
            decimal actual = DecimalMath.PI / 2.0M;
            actual = DecimalMath.Cos(actual);
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Cos_Negative()
        {
            decimal expected = -1.0M;
            decimal actual = DecimalMath.PI;
            actual = DecimalMath.Cos(actual);
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Sin_One()
        {
            decimal expected = 1.0M;
            decimal actual = DecimalMath.PI / 2.0M;
            actual = DecimalMath.Sin(actual);
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Sin_Zero()
        {
            decimal expected = 0.0M;
            decimal actual = DecimalMath.PI;
            actual = DecimalMath.Sin(actual);
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Tan_Sqrt3()
        {
            const decimal THREE = 3.0M;
            decimal expected = DecimalMath.Sqrt(THREE);
            decimal actual = DecimalMath.PI / THREE;
            actual = DecimalMath.Tan(actual);

            expected = Math.Round(expected, 22);    //1.7320508075688772935274463415
            actual = Math.Round(actual, 22);        //1.7320508075688772935274463414

            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod]
        public void Tan_Exception()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => DecimalMath.Tan(DecimalMath.PI / 2));
        }
    }
}
