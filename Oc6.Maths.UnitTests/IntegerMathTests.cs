using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class IntegerMathTests
    {
        [TestMethod]
        public void Sqrt_Zero_Int()
        {
            int actual = IntegerMath.Sqrt(0);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_One_Int()
        {
            int actual = IntegerMath.Sqrt(1);
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Two_Int()
        {
            int actual = IntegerMath.Sqrt(2);
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Four_Int()
        {
            int actual = IntegerMath.Sqrt(4);
            int expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Nine_Int()
        {
            int actual = IntegerMath.Sqrt(9);
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_16_Int()
        {
            int actual = IntegerMath.Sqrt(16);
            int expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_16_Short()
        {
            short value = 16;
            short actual = IntegerMath.Sqrt(value);
            short expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_16_Sbyte()
        {
            sbyte value = 16;
            sbyte actual = IntegerMath.Sqrt(value);
            sbyte expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_16_Ulong()
        {
            ulong value = 16;
            ulong actual = IntegerMath.Sqrt(value);
            ulong expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Max_Int()
        {
            int actual = IntegerMath.Sqrt(int.MaxValue);
            int expected = 46340;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Exception_Int()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IntegerMath.Sqrt(-1));
        }

        [TestMethod]
        public void Sqrt_Zero_Long()
        {
            long actual = IntegerMath.Sqrt(0L);
            long expected = 0L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_One_Long()
        {
            long actual = IntegerMath.Sqrt(1L);
            long expected = 1L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Two_Long()
        {
            long actual = IntegerMath.Sqrt(2L);
            long expected = 1L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Four_Long()
        {
            long actual = IntegerMath.Sqrt(4L);
            long expected = 2L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Nine_Long()
        {
            long actual = IntegerMath.Sqrt(9L);
            long expected = 3L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_16_Long()
        {
            long actual = IntegerMath.Sqrt(16L);
            long expected = 4L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Mid_Low_Long()
        {
            long actual = IntegerMath.Sqrt(3037000498L);
            long expected = 55108L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Mid_High_Long()
        {
            long actual = IntegerMath.Sqrt(3037000499L);
            long expected = 55108L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Max_Long()
        {
            long actual = IntegerMath.Sqrt(long.MaxValue);
            long expected = 3037000499L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Max_Ulong()
        {
            ulong actual = IntegerMath.Sqrt(ulong.MaxValue);
            ulong expected = 4294967295;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Exception_Long()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IntegerMath.Sqrt(-1L));
        }
    }
}
