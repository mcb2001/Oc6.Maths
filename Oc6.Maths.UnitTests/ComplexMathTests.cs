using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class ComplexMathTests
    {
        [TestMethod]
        public void Conjugate()
        {
            Complex actual = new Complex
            {
                Real = 1.2,
                Imaginary = 7.8,
            };

            Complex expected = new Complex
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

            Complex complex = new Complex
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
            Complex actual = new Complex
            {
                Real = -3.5,
                Imaginary = 3.5,
            };

            Complex expected = new Complex
            {
                Real = 85.75,
                Imaginary = 85.75,
            };

            actual = ComplexMath.Pow(actual, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Round()
        {
            Complex expected = new Complex
            {
                Real = -172,
                Imaginary = 172,
            };

            Complex actual = new Complex
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
            Complex expected = new Complex
            {
                Real = 4,
                Imaginary = 0,
            };

            Complex actual = new Complex
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
            Complex expected = new Complex
            {
                Real = 0,
                Imaginary = 4,
            };

            Complex actual = new Complex
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
            Complex expected = new Complex
            {
                Real = 2,
                Imaginary = 1,
            };

            Complex actual = new Complex
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
            Complex expected = new Complex
            {
                Real = 4,
                Imaginary = 0,
            };

            Complex actual = new Complex
            {
                Real = 4 * 4 * 4,
                Imaginary = 0,
            };

            actual = ComplexMath.Root(actual, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Root()
        {
            //https://en.wikipedia.org/wiki/Complex_number
            Complex expected = new Complex
            {
                Real = 1.5399560877219816,
                Imaginary = 0.47227133305169505,
            };

            Complex actual = new Complex
            {
                Real = 2.5,
                Imaginary = 6.25,
            };

            actual = ComplexMath.Root(actual, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Root_Negative()
        {
            //https://en.wikipedia.org/wiki/Complex_number
            Complex expected = new Complex
            {
                Real = 0.593545246206821,
                Imaginary = -0.18202753110139264,
            };

            Complex actual = new Complex
            {
                Real = 2.5,
                Imaginary = 6.25,
            };

            actual = ComplexMath.Root(actual, -4);
            Assert.AreEqual(expected, actual);
        }
    }
}
