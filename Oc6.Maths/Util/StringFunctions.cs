using System;

namespace Oc6.Maths.Util
{
    public static class StringFunctions
    {
        public static string LongestCommonSubString(string left, string right)
        {
            if (left is null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right is null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            if (left.CompareTo(right) == 0 || right.StartsWith(left) || right.EndsWith(left))
            {
                return left;
            }

            if (left.StartsWith(right))
            {
                return right;
            }

            if (left.EndsWith(right))
            {
                return right;
            }

            char[] S = left.ToCharArray();
            char[] T = right.ToCharArray();
            int m = S.Length;
            int n = T.Length;
            char[] temp;

            int[,] L = new int[m, n];
            int z = 0;
            string ret = string.Empty;

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (S[i] == T[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            L[i, j] = 1;
                        }
                        else
                        {
                            L[i, j] = L[i - 1, j - 1] + 1;
                        }
                        if (L[i, j] > z)
                        {
                            z = L[i, j];
                            temp = new char[z];
                            Array.Copy(S, i - z + 1, temp, 0, z);
                            ret = new string(temp);
                        }
                    }
                    else
                    {
                        L[i, j] = 0;
                    }
                }
            }

            return ret;
        }
    }
}
