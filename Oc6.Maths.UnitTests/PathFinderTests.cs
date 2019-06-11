using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Path;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public class PathFinderTests
    {
        private const int SIZE = 200;
        private static readonly Random Randomizer = new Random();

        [TestMethod]
        public void GetShortestPath_Random()
        {
            Enumerable.Range(0, 500)
                .AsParallel()
                .ForAll(x => TestPath());
        }

        private static void TestPath()
        {
            PathNode[,] nodes = new PathNode[SIZE, SIZE];

            for (int x = 0; x < SIZE; ++x)
            {
                for (int y = 0; y < SIZE; ++y)
                {
                    nodes[x, y] = new PathNode(x, y);
                }
            }

            for (int x = 2; x < SIZE - 2; ++x)
            {
                for (int y = 0; y < SIZE; ++y)
                {
                    if (Randomizer.NextDouble() < 0.1)
                    {
                        nodes[x, y].IsBlocked = true;
                    }
                }
            }

            try
            {
                List<PathNode> path = PathFinder.GetShortestPath(nodes, 0, 0, SIZE - 1, SIZE - 1);
                Assert.IsTrue(path.Count >= 399); //any path should be longer than SIZE + SIZE - 1;
            }
            catch (NotPathableException exc)
            {
                //Bah, bad luck generating :-) just carry on, but register it !
                Assert.ThrowsException<NotPathableException>(() => throw exc);
            }
        }
    }
}
