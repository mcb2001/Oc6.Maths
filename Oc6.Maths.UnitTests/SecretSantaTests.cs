using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Util;
using System.Collections.Generic;
using System.Linq;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class SecretSantaTests
    {
        [TestMethod]
        public void Solve()
        {
            IList<string> participantNames = Enumerable
                .Range('a', 'z' - 'a' + 1)
                .Select(i => string.Join(string.Empty, Enumerable
                    .Range(0, 4)
                    .Select(x => (char)i)))
                .ToArray();
            //["aaaa", "bbbb", ... , "yyyy", "zzzz"]

            IList<SecretSantaParticipant> solution = SecretSanta.Solve(participantNames);

            Assert.AreEqual(participantNames.Count, solution.Count);

            foreach (SecretSantaParticipant element in solution)
            {
                Assert.AreNotEqual(element.Are, element.IsFor);
            }
        }
    }
}
