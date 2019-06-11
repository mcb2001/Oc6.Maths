using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class ComplexMathTests
    {
        [TestMethod]
        public void Conjugate()
        {
            var actual = new Complex
            {
                Real = 1.2,
                Imaginary = 7.8,
            };

            var expected = new Complex
            {
                Real = 1.2,
                Imaginary = -7.8,
            };

            actual = ComplexMath.Conjugate(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Length()
        {
            double expected = 5.0;

            var complex = new Complex
            {
                Real = 3.0,
                Imaginary = 4.0,
            };

            double actual = ComplexMath.Length(complex);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Pow()
        {
            var actual = new Complex
            {
                Real = -3.5,
                Imaginary = 3.5,
            };

            var expected = new Complex
            {
                Real = -171.5,
                Imaginary = 171.5,
            };

            actual = ComplexMath.Pow(actual, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Round()
        {
            var expected = new Complex
            {
                Real = -172,
                Imaginary = 172,
            };

            var actual = new Complex
            {
                Real = -171.5,
                Imaginary = 171.5,
            };

            actual = ComplexMath.Round(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Real()
        {
            var expected = new Complex
            {
                Real = 4,
                Imaginary = 0,
            };

            var actual = new Complex
            {
                Real = 16,
                Imaginary = 0,
            };

            actual = ComplexMath.Sqrt(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Imaginary()
        {
            var expected = new Complex
            {
                Real = 0,
                Imaginary = 4,
            };

            var actual = new Complex
            {
                Real = -16,
                Imaginary = 0,
            };

            actual = ComplexMath.Sqrt(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt()
        {
            var expected = new Complex
            {
                Real = 2,
                Imaginary = 1,
            };

            var actual = new Complex
            {
                Real = 3,
                Imaginary = 4,
            };

            actual = ComplexMath.Sqrt(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Root_Real()
        {
            //https://en.wikipedia.org/wiki/Complex_number
            var expected = new Complex
            {
                Real = 4,
                Imaginary = 0,
            };

            var actual = new Complex
            {
                Real = 16,
                Imaginary = 0,
            };

            actual = ComplexMath.Root(actual, 3);
            Assert.AreEqual(expected, actual);
        }
    }
}
