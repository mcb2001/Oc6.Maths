using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Util;
using System;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class StringFunctionsTests
    {
        [TestMethod]
        public void LongestCommonSubStringNullAny()
        {
            Assert.ThrowsException<ArgumentNullException>(() => StringFunctions.LongestCommonSubString(null, "any"));
        }

        [TestMethod]
        public void LongestCommonSubStringAnyNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => StringFunctions.LongestCommonSubString("any", null));
        }

        [TestMethod]
        public void LongestCommonSubStringStartsWith0()
        {
            string a = "aaaabbbbb";
            string b = "aaaa";
            string expected = b;
            string actual = StringFunctions.LongestCommonSubString(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongestCommonSubStringStartsWith1()
        {
            string a = "aaaabbbbb";
            string b = "aaaa";
            string expected = b;
            string actual = StringFunctions.LongestCommonSubString(b, a);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongestCommonSubStringEndsWith0()
        {
            string a = "aaaabbbb";
            string b = "bbbb";
            string expected = b;
            string actual = StringFunctions.LongestCommonSubString(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongestCommonSubStringEndsWith1()
        {
            string a = "aaaabbbb";
            string b = "bbbb";
            string expected = b;
            string actual = StringFunctions.LongestCommonSubString(b, a);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongestCommonSubStringSelf()
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
