using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Numbers;
using System;
using System.Numerics;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public sealed class IntegerMathTests
    {
        [TestMethod]
        public void GreatestCommonDivisorInt()
        {
            int a = 2 * 3 * 5 * 7;
            int b = 3 * 5 * 7;
            int c = 2 * 5 * 7;
            int expected = 5 * 7;
            int actual = IntegerMath.GreatestCommonDivisor(a, b, c);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GreatestCommonDivisorBigInteger()
        {
            BigInteger a = 2 * 3 * 5 * 7;
            BigInteger b = 3 * 5 * 7;
            BigInteger c = 2 * 5 * 7;
            BigInteger expected = 5 * 7;
            BigInteger actual = IntegerMath.GreatestCommonDivisor(a, b, c);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LeastCommonMultipleLong()
        {
            long a = 2 * 3 * 5 * 7;
            long b = 3 * 5 * 11;
            long c = 3 * 5 * 13;
            long expected = 2 * 3 * 5 * 7 * 11 * 13;
            long actual = IntegerMath.LeastCommonMultiple(a, b, c);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LeastCommonMultipleBigInteger()
        {
            BigInteger a = 2 * 3 * 5 * 7;
            BigInteger b = 3 * 5 * 11;
            BigInteger c = 3 * 5 * 13;
            BigInteger expected = 2 * 3 * 5 * 7 * 11 * 13;
            BigInteger actual = IntegerMath.LeastCommonMultiple(a, b, c);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtZeroInt()
        {
            int actual = IntegerMath.Sqrt(0);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtOneInt()
        {
            int actual = IntegerMath.Sqrt(1);
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtTwoInt()
        {
            int actual = IntegerMath.Sqrt(2);
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtFourInt()
        {
            int actual = IntegerMath.Sqrt(4);
            int expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtNineInt()
        {
            int actual = IntegerMath.Sqrt(9);
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt16Int()
        {
            int actual = IntegerMath.Sqrt(16);
            int expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt16Short()
        {
            short value = 16;
            short actual = IntegerMath.Sqrt(value);
            short expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt16Sbyte()
        {
            sbyte value = 16;
            sbyte actual = IntegerMath.Sqrt(value);
            sbyte expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt16Ulong()
        {
            ulong value = 16;
            ulong actual = IntegerMath.Sqrt(value);
            ulong expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtMaxInt()
        {
            int actual = IntegerMath.Sqrt(int.MaxValue);
            int expected = 46340;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtExceptionInt()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IntegerMath.Sqrt(-1));
        }

        [TestMethod]
        public void SqrtZeroLong()
        {
            long actual = IntegerMath.Sqrt(0L);
            long expected = 0L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtOneLong()
        {
            long actual = IntegerMath.Sqrt(1L);
            long expected = 1L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtTwoLong()
        {
            long actual = IntegerMath.Sqrt(2L);
            long expected = 1L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtFourLong()
        {
            long actual = IntegerMath.Sqrt(4L);
            long expected = 2L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtNineLong()
        {
            long actual = IntegerMath.Sqrt(9L);
            long expected = 3L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt16Long()
        {
            long actual = IntegerMath.Sqrt(16L);
            long expected = 4L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt16BigInteger()
        {
            BigInteger actual = 16;
            actual = IntegerMath.Sqrt(actual);
            BigInteger expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt10BigInteger()
        {
            BigInteger actual = 10;
            actual = IntegerMath.Sqrt(actual);
            BigInteger expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtLargeBigInteger0()
        {
            BigInteger actual = long.MaxValue;
            actual = IntegerMath.Sqrt(actual * actual);
            BigInteger expected = long.MaxValue;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtLargeBigInteger1()
        {
            BigInteger actual = long.MaxValue;
            actual = IntegerMath.Sqrt((actual * actual) + 27);
            BigInteger expected = long.MaxValue;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtMidLowLong()
        {
            long actual = IntegerMath.Sqrt(3037000498L);
            long expected = 55108L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtMidHighLong()
        {
            long actual = IntegerMath.Sqrt(3037000499L);
            long expected = 55108L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtMaxLong()
        {
            long actual = IntegerMath.Sqrt(long.MaxValue);
            long expected = 3037000499L;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtMaxUlong()
        {
            ulong actual = IntegerMath.Sqrt(ulong.MaxValue);
            ulong expected = 4294967295;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SqrtExceptionLong()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => IntegerMath.Sqrt(-1L));
        }

        [TestMethod]
        public void IsPowerOfTwoTrue16Byte()
        {
            byte b = 16;
            Assert.IsTrue(IntegerMath.IsPowerOfTwo(b));
        }

        [TestMethod]
        public void IsPowerOfTwoFalse0Uint()
        {
            uint u = 0;
            Assert.IsFalse(IntegerMath.IsPowerOfTwo(u));
        }

        [TestMethod]
        public void IsPowerOfTwoTrue1Int()
        {
            int i = 1;
            Assert.IsTrue(IntegerMath.IsPowerOfTwo(i));
        }

        [TestMethod]
        public void IsPowerOfTwoFalse3Short()
        {
            short s = 3;
            Assert.IsFalse(IntegerMath.IsPowerOfTwo(s));
        }

        [TestMethod]
        public void IsPowerOfTwoFalse127Sbyte()
        {
            sbyte s = 127;
            Assert.IsFalse(IntegerMath.IsPowerOfTwo(s));
        }

        [TestMethod]
        public void IsPowerOfTwoTrueLargeLong()
        {
            long l = int.MaxValue;
            ++l;
            Assert.IsTrue(IntegerMath.IsPowerOfTwo(l));
        }

        [TestMethod]
        public void IsPowerOfTwoFalseMAXulong()
        {
            ulong u = ulong.MaxValue;
            Assert.IsFalse(IntegerMath.IsPowerOfTwo(u));
        }

        [TestMethod]
        public void IsPowerOfTwoTrueLoop()
        {
            ulong u = 1;

            for (int i = 0; i < 64; ++i)
            {
                Assert.IsTrue(IntegerMath.IsPowerOfTwo(u));
                u <<= 1;
            }
        }
    }
}
