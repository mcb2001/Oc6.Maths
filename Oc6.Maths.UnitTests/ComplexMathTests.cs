using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class ComplexMathTests
    {
        [TestMethod]
        public void Conjugate()
        {
            var A = new Complex
            {
                Real = 1.2,
                Imaginary = 7.8,
            };

            var expected = new Complex
            {
                Real = 1.2,
                Imaginary = -7.8,
            };

            Complex actual = ComplexMath.Conjugate(A);
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
            var B = new Complex
            {
                Real = -3.5,
                Imaginary = 3.5,
            };

            var expected = new Complex
            {
                Real = -171.5,
                Imaginary = 171.5,
            };

            Complex actual = ComplexMath.Pow(B, 3);
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
        public void Sqrt()
        {

        }
    }
}
