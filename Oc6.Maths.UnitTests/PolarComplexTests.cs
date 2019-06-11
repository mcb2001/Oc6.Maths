using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class PolarComplexTests
    {
        [TestMethod]
        public void FromComplex()
        {
            Complex complex = new Complex
            {
                Real = 2.5,
                Imaginary = 6.25,
            };

            PolarComplex expected = new PolarComplex
            {
                Argument = 1.1902899496825317,
                Modulus = 6.73145600891813,
            };

            PolarComplex actual = PolarComplex.FromComplex(complex);
            Assert.AreEqual(expected, actual);
        }
    }
}
