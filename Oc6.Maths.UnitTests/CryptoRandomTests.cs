using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Cryptography;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public sealed class CryptoRandomTests
    {
        [TestMethod]
        public void NextInt32()
        {
            using (var random = new CryptoRandom())
            {
                for (int i = 0; i < 100; ++i)
                {
                    int value = random.Next<int>();
                    Assert.IsTrue(value <= int.MaxValue);
                    Assert.IsTrue(value >= int.MinValue);
                }
            }
        }
    }
}
