using Oc6.Maths.Cryptography;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Oc6.Maths.Util
{
    public static class IListExtensions
    {
        private static readonly Random _randomizer = new Random();

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            return ShuffleInternally(list, (min, max) => _randomizer.Next(min, max));
        }

        public static IList<T> ShuffleCryptographically<T>(this IList<T> list, RandomNumberGenerator randomNumberGenerator = null, bool doNotDispose = false)
        {
            try
            {
                if (list is null)
                {
                    throw new ArgumentNullException(nameof(list));
                }

                if (randomNumberGenerator == null)
                {
                    randomNumberGenerator = RandomNumberGenerator.Create();
                }

                using (var random = new CryptoRandom(randomNumberGenerator, doNotDispose))
                {
                    return ShuffleInternally(list, (min, max) =>
                    {
                        int i;

                        do
                        {
                            random.TryNext<int>(out i);

                            if (i == int.MaxValue)
                            {
                                i = 0;
                            }

                            i = Math.Abs(i);
                        } while (i == int.MaxValue);

                        int diff = max - min;
                        int part = int.MaxValue / diff;
                        int value = i / part;
                        return value + min;
                    });
                }
            }
            finally
            {
                if (!doNotDispose)
                {
                    randomNumberGenerator?.Dispose();
                }
            }
        }



        private static IList<T> ShuffleInternally<T>(IList<T> list, Func<int, int, int> next)
        {
            for (int i = list.Count - 1; i > 0; --i)
            {
                int j = next(0, i + 1);
                T a = list[i];
                list[i] = list[j];
                list[j] = a;
            }

            return list;
        }
    }
}
