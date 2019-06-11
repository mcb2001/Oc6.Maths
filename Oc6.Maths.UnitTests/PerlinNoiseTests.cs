using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class PerlinNoiseTests
    {
        [TestMethod]
        public void Noise()
        {
            const double expected = 0.13691995878400012;
            double actual = PerlinNoise.Noise(3.14, 42, 7);
            Assert.AreEqual<double>(expected, actual);
        }
    }
}
