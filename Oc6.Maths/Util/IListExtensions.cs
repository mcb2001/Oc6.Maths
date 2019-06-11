using System;
using System.Collections.Generic;

namespace Oc6.Maths.Util
{
    public static class IListExtensions
    {
        private static readonly Random _randomizer = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            for (int i = list.Count - 1; i > 0; --i)
            {
                int j = _randomizer.Next(0, i + 1);
                T a = list[i];
                list[i] = list[j];
                list[j] = a;
            }
        }
    }
}
