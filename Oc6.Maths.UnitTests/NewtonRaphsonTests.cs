using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Util;
using System;
using System.Numerics;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class NewtonRaphsonTests
    {
        [TestMethod]
        public void IterateIterationsExceededException()
        {
            Func<double, double> fx = x => Math.Pow(x, 8) - 100.0;
            Func<double, double> dydx = x => 8 * Math.Pow(x, 7);
            Assert.ThrowsException<IterationsExceededException<double>>(() => NewtonRaphson.Iterate(fx, dydx, iterations: 10));
        }

        [TestMethod]
        public void Iterate()
        {
            Func<double, double> fx = x => Math.Pow(x, 8) - 100.0;
            Func<double, double> dydx = x => 8 * Math.Pow(x, 7);
            double actual = NewtonRaphson.Iterate(fx, dydx);
            double expected = 1.77827941003892;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IterateComplexReal()
        {
            Func<Complex, Complex> fx = x => Complex.Pow(x, 2) - 4;
            Func<Complex, Complex> dydx = x => 2 * x;

            var expected = Complex.Sqrt(4);

            Complex actual = Iterate(fx, dydx);

            Assert.AreEqual<Complex>(expected, actual);
        }

        private static Complex Iterate(Func<Complex, Complex> fx, Func<Complex, Complex> dydx, Complex? guess = null)
        {
            try
            {
                return guess.HasValue ? NewtonRaphson.Iterate(fx, dydx, guess) : NewtonRaphson.Iterate(fx, dydx);
            }
            catch (IterationsExceededException<Complex> exc)
            {
                return exc.LastValue;
            }
        }

        [TestMethod]
        public void IterateComplexImaginary()
        {
            Func<Complex, Complex> fx = x => Complex.Pow(x, 2) + 4;
            Func<Complex, Complex> dydx = x => 2 * x;

            var expected = Complex.Sqrt(-4);

            Complex actual = Iterate(fx, dydx, new Complex(0, 4));

            Assert.AreEqual<Complex>(expected, actual);
        }
    }
}
