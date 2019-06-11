using System;
using System.Numerics;

namespace Oc6.Maths
{
    public static class IntegerMath
    {
        public static sbyte Sqrt(sbyte input)
        {
            return (sbyte)SignedSqrtInternal(input);
        }

        public static byte Sqrt(byte input)
        {
            if (input < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input), "Must be non-negative");
            }

            return (byte)SqrtInternal(input);
        }

        public static short Sqrt(short input)
        {
            return (short)SignedSqrtInternal(input);
        }

        public static ushort Sqrt(ushort input)
        {
            return (ushort)SqrtInternal(input);
        }

        public static int Sqrt(int input)
        {
            return (int)SignedSqrtInternal(input);
        }

        public static uint Sqrt(uint input)
        {
            return (uint)SqrtInternal(input);
        }

        public static long Sqrt(long input)
        {
            return (long)SignedSqrtInternal(input);
        }

        public static ulong Sqrt(ulong input)
        {
            return SqrtInternal(input);
        }

        public static BigInteger Sqrt(BigInteger input)
        {
            if (input < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input), "Must be non-negative");
            }

            if (input == 0)
            {
                return 0;
            }

            BigInteger t;

            try
            {
                t = NewtonRaphson.Iterate(x => (x * x) - input, x => 2 * x, 2147483648);
            }
            catch (IterationsExceededException<BigInteger> exc)
            {
                t = exc.LastValue;
            }

            if (t * t == input)
            {
                return t;
            }

            --t;

            BigInteger prev = t * t;

            while (true)
            {
                ++t;

                BigInteger cur = t * t;

                if (cur < prev || cur > input)
                {
                    break;
                }
            }

            return t - 1;
        }

        public static bool IsPowerOfTwo(sbyte x)
        {
            return x > 0 && IsPowerOfTwoInternal((ulong)x);
        }

        public static bool IsPowerOfTwo(byte x)
        {
            return x > 0 && IsPowerOfTwoInternal(x);
        }

        public static bool IsPowerOfTwo(short x)
        {
            return x > 0 && IsPowerOfTwoInternal((ulong)x);
        }

        public static bool IsPowerOfTwo(ushort x)
        {
            return IsPowerOfTwoInternal(x);
        }

        public static bool IsPowerOfTwo(int x)
        {
            return x > 0 && IsPowerOfTwoInternal((ulong)x);
        }

        public static bool IsPowerOfTwo(uint x)
        {
            return IsPowerOfTwoInternal(x);
        }

        public static bool IsPowerOfTwo(long x)
        {
            return x > 0 && IsPowerOfTwoInternal((ulong)x);
        }

        public static bool IsPowerOfTwo(ulong x)
        {
            return IsPowerOfTwoInternal(x);
        }

        private static ulong SignedSqrtInternal(long input)
        {
            if (input < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input), "Must be non-negative");
            }

            return SqrtInternal((ulong)input);
        }

        private static ulong SqrtInternal(ulong input)
        {
            if (input == 0)
            {
                return 0;
            }

            double i = input;
            double value;

            try
            {
                value = NewtonRaphson.Iterate(x => (x * x) - i, x => 2.0 * x, 2147483648);
            }
            catch (IterationsExceededException<double> exc)
            {
                value = exc.LastValue;
            }

            ulong t = (ulong)value;

            while (t * t < t)
            {
                --t;
            }

            ulong prev = t * t;

            while (true)
            {
                ++t;

                ulong cur = t * t;

                if (cur < prev || cur > input)
                {
                    break;
                }
            }

            return t - 1;
        }

        private static bool IsPowerOfTwoInternal(ulong x)
        {
            switch (x)
            {
                case 0b0000000000000000000000000000000000000000000000000000000000000001:
                case 0b0000000000000000000000000000000000000000000000000000000000000010:
                case 0b0000000000000000000000000000000000000000000000000000000000000100:
                case 0b0000000000000000000000000000000000000000000000000000000000001000:
                case 0b0000000000000000000000000000000000000000000000000000000000010000:
                case 0b0000000000000000000000000000000000000000000000000000000000100000:
                case 0b0000000000000000000000000000000000000000000000000000000001000000:
                case 0b0000000000000000000000000000000000000000000000000000000010000000:
                case 0b0000000000000000000000000000000000000000000000000000000100000000:
                case 0b0000000000000000000000000000000000000000000000000000001000000000:
                case 0b0000000000000000000000000000000000000000000000000000010000000000:
                case 0b0000000000000000000000000000000000000000000000000000100000000000:
                case 0b0000000000000000000000000000000000000000000000000001000000000000:
                case 0b0000000000000000000000000000000000000000000000000010000000000000:
                case 0b0000000000000000000000000000000000000000000000000100000000000000:
                case 0b0000000000000000000000000000000000000000000000001000000000000000:
                case 0b0000000000000000000000000000000000000000000000010000000000000000:
                case 0b0000000000000000000000000000000000000000000000100000000000000000:
                case 0b0000000000000000000000000000000000000000000001000000000000000000:
                case 0b0000000000000000000000000000000000000000000010000000000000000000:
                case 0b0000000000000000000000000000000000000000000100000000000000000000:
                case 0b0000000000000000000000000000000000000000001000000000000000000000:
                case 0b0000000000000000000000000000000000000000010000000000000000000000:
                case 0b0000000000000000000000000000000000000000100000000000000000000000:
                case 0b0000000000000000000000000000000000000001000000000000000000000000:
                case 0b0000000000000000000000000000000000000010000000000000000000000000:
                case 0b0000000000000000000000000000000000000100000000000000000000000000:
                case 0b0000000000000000000000000000000000001000000000000000000000000000:
                case 0b0000000000000000000000000000000000010000000000000000000000000000:
                case 0b0000000000000000000000000000000000100000000000000000000000000000:
                case 0b0000000000000000000000000000000001000000000000000000000000000000:
                case 0b0000000000000000000000000000000010000000000000000000000000000000:
                case 0b0000000000000000000000000000000100000000000000000000000000000000:
                case 0b0000000000000000000000000000001000000000000000000000000000000000:
                case 0b0000000000000000000000000000010000000000000000000000000000000000:
                case 0b0000000000000000000000000000100000000000000000000000000000000000:
                case 0b0000000000000000000000000001000000000000000000000000000000000000:
                case 0b0000000000000000000000000010000000000000000000000000000000000000:
                case 0b0000000000000000000000000100000000000000000000000000000000000000:
                case 0b0000000000000000000000001000000000000000000000000000000000000000:
                case 0b0000000000000000000000010000000000000000000000000000000000000000:
                case 0b0000000000000000000000100000000000000000000000000000000000000000:
                case 0b0000000000000000000001000000000000000000000000000000000000000000:
                case 0b0000000000000000000010000000000000000000000000000000000000000000:
                case 0b0000000000000000000100000000000000000000000000000000000000000000:
                case 0b0000000000000000001000000000000000000000000000000000000000000000:
                case 0b0000000000000000010000000000000000000000000000000000000000000000:
                case 0b0000000000000000100000000000000000000000000000000000000000000000:
                case 0b0000000000000001000000000000000000000000000000000000000000000000:
                case 0b0000000000000010000000000000000000000000000000000000000000000000:
                case 0b0000000000000100000000000000000000000000000000000000000000000000:
                case 0b0000000000001000000000000000000000000000000000000000000000000000:
                case 0b0000000000010000000000000000000000000000000000000000000000000000:
                case 0b0000000000100000000000000000000000000000000000000000000000000000:
                case 0b0000000001000000000000000000000000000000000000000000000000000000:
                case 0b0000000010000000000000000000000000000000000000000000000000000000:
                case 0b0000000100000000000000000000000000000000000000000000000000000000:
                case 0b0000001000000000000000000000000000000000000000000000000000000000:
                case 0b0000010000000000000000000000000000000000000000000000000000000000:
                case 0b0000100000000000000000000000000000000000000000000000000000000000:
                case 0b0001000000000000000000000000000000000000000000000000000000000000:
                case 0b0010000000000000000000000000000000000000000000000000000000000000:
                case 0b0100000000000000000000000000000000000000000000000000000000000000:
                case 0b1000000000000000000000000000000000000000000000000000000000000000:
                    return true;
                default:
                    return false;
            }
        }
    }
}
