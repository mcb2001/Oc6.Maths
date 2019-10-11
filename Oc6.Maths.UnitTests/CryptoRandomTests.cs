using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Cryptography;
using System.Security.Cryptography;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public sealed class CryptoRandomTests
    {
        [TestMethod]
        public void TryNextInt32()
        {
            using (var random = new CryptoRandom())
            {
                for (int i = 0; i < 100; ++i)
                {
                    Assert.IsTrue(random.TryNext(out int value));
                    Assert.IsTrue(value <= int.MaxValue);
                    Assert.IsTrue(value >= int.MinValue);
                }
            }
        }

        [TestMethod]
        public void DoNotDispose()
        {
            TestRandomNumberGenerator generator;

            using (generator = new TestRandomNumberGenerator())
            {
                using (var random = new CryptoRandom(generator, doNotDispose: true))
                {
                    Assert.IsTrue(random.TryNext(out int value));
                    Assert.IsTrue(value <= int.MaxValue);
                    Assert.IsTrue(value >= int.MinValue);

                    Assert.IsFalse(generator.IsDisposed);
                }

                Assert.IsFalse(generator.IsDisposed);
            }

            Assert.IsTrue(generator.IsDisposed);
        }

        [TestMethod]
        public void TryNextInt32Predictable()
        {
            using (var generator = new TestRandomNumberGenerator())
            {
                using (var random = new CryptoRandom(generator))
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        Assert.IsTrue(random.TryNext(out int value));
                        Assert.AreEqual<int>(50462976, value);
                    }
                }
            }
        }

        private sealed class TestRandomNumberGenerator : RandomNumberGenerator
        {
            public bool IsDisposed { get; private set; } = false;

            public override void GetBytes(byte[] data)
            {
                for (int i = 0; i < data.Length; ++i)
                {
                    data[i] = (byte)(i % (byte.MaxValue + 1));
                }
            }

            protected override void Dispose(bool disposing)
            {
                IsDisposed = true;
                base.Dispose(disposing);
            }
        }
    }
}
