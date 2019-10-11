using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Util;
using System;

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
    }
}
