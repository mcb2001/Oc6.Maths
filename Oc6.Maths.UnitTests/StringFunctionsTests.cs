using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Util;
using System;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class StringFunctionsTests
    {
        [TestMethod]
        public void LongestCommonSubString_Null_Any()
        {
            Assert.ThrowsException<ArgumentNullException>(() => StringFunctions.LongestCommonSubString(null, "any"));
        }

        [TestMethod]
        public void LongestCommonSubString_Any_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => StringFunctions.LongestCommonSubString("any", null));
        }

        [TestMethod]
        public void LongestCommonSubString_StartsWith0()
        {
            string a = "aaaabbbbb";
            string b = "aaaa";
            string expected = b;
            string actual = StringFunctions.LongestCommonSubString(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongestCommonSubString_StartsWith1()
        {
            string a = "aaaabbbbb";
            string b = "aaaa";
            string expected = b;
            string actual = StringFunctions.LongestCommonSubString(b, a);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongestCommonSubString_EndsWith0()
        {
            string a = "aaaabbbb";
            string b = "bbbb";
            string expected = b;
            string actual = StringFunctions.LongestCommonSubString(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongestCommonSubString_EndsWith1()
        {
            string a = "aaaabbbb";
            string b = "bbbb";
            string expected = b;
            string actual = StringFunctions.LongestCommonSubString(b, a);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongestCommonSubString_Self()
        {
            string a = "aaaabbbb";
            string expected = a;
            string actual = StringFunctions.LongestCommonSubString(a, a);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongestCommonSubString()
        {
            string a = "aabbaaabbccbb";
            string b = "caaac";
            string expected = "aaa";
            string actual = StringFunctions.LongestCommonSubString(a, b);
            Assert.AreEqual(expected, actual);
        }
    }
}
