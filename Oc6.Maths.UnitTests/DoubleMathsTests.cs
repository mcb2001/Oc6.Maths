using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Numbers;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public sealed class DoubleMathsTests
    {
        [TestMethod]
        public void Root()
        {
            const double expected = 100.0;
            double actual = expected * expected * expected;
            actual = DoubleMath.Root(actual, 3);
            Assert.AreEqual<double>(expected, actual);
        }
    }
}
