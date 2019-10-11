using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Util;
using System.Linq;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class IListExtensionsTests
    {
        [TestMethod]
        public void ShuffleCryptographically()
        {
            int[] a = Enumerable.Range(0, 100).ToArray();
            int[] b = Enumerable.Range(0, 100).ToArray();

            a.ShuffleCryptographically();
            b.ShuffleCryptographically();

            bool test = true;

            for (int i = 0; i < a.Length; ++i)
            {
                test &= a[i] == b[i];
            }

            Assert.IsFalse(test);
        }

        [TestMethod]
        public void ShuffleArray()
        {
            int[] a = Enumerable.Range(0, 100).ToArray();
            int[] b = Enumerable.Range(0, 100).ToArray();

            a.Shuffle();
            b.Shuffle();

            bool test = true;

            for (int i = 0; i < a.Length; ++i)
            {
                test &= a[i] == b[i];
            }

            Assert.IsFalse(test);
        }

        [TestMethod]
        public void ShuffleList()
        {
            var a = Enumerable.Range(0, 100).ToList();
            var b = Enumerable.Range(0, 100).ToList();

            a.Shuffle();
            b.Shuffle();

            bool test = true;

            for (int i = 0; i < a.Count; ++i)
            {
                test &= a[i] == b[i];
            }

            Assert.IsFalse(test);
        }
    }
}
