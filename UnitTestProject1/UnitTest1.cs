using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using graph_1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void isOrientedGraph()
        {
            int[,] notOriented = { { 0, 1, 0, 0 }, { 1, 1, 0, 1 }, { 0, 0, 0, 0 }, { 0, 1, 0, 0 } };
            int[,] oriented = { { 0, 1, 0, 0 }, { 1, 1, 0, 1 }, { 1, 0, 0, 0 }, { 0, 1, 0, 0 } };
            AdjacencyMatrix notOrientedMatrix = new AdjacencyMatrix(notOriented);
            AdjacencyMatrix orientedMatrix = new AdjacencyMatrix(oriented);

            Graph notOrientedGraph = new Graph(notOrientedMatrix);
            Graph orientedGraph = new Graph(orientedMatrix);

            Assert.AreEqual(notOrientedGraph.isOrientedByAdjacencyMatrix(), false, "not or "+ notOrientedMatrix.isOriented().ToString());
            Assert.AreEqual(orientedGraph.isOrientedByAdjacencyMatrix(), true, "or " + notOrientedMatrix.isOriented().ToString());
        }

        [TestMethod]
        public void isPseudograph()
        {
            int[,] pseudo = { { 0, 1, 0, 0 }, { 1, 1, 0, 1 }, { 0, 0, 0, 0 }, { 0, 1, 0, 1 } };
            int[,] notPseudo = { { 0, 1, 0, 0 }, { 1, 0, 0, 1 }, { 1, 0, 0, 0 }, { 0, 1, 0, 0 } };
            AdjacencyMatrix pseudoMatrix = new AdjacencyMatrix(pseudo);
            AdjacencyMatrix notPseudoMatrix = new AdjacencyMatrix(notPseudo);

            Graph notPseudoGraph = new Graph(notPseudoMatrix);
            Graph pseudoGraph = new Graph(pseudoMatrix);

            Assert.AreEqual(notPseudoGraph.isPseudographByAdjacencyMatrix(), false, "not pseud ");
            Assert.AreEqual(pseudoGraph.isPseudographByAdjacencyMatrix(), true, "pseud");
        }

        [TestMethod]
        public void isMultigraph()
        {
            int[,] multi = { { 0, 1, 0, 0 }, { 1, 1, 0, 1 }, { 0, 0, 0, 5 }, { 0, 1, 0, 1 } };
            int[,] notMulti = { { 0, 1, 0, 0 }, { 1, 0, 0, 1 }, { 1, 0, 0, 0 }, { 0, 1, 0, 0 } };
            AdjacencyMatrix multiMatrix = new AdjacencyMatrix(multi);
            AdjacencyMatrix notMultiMatrix = new AdjacencyMatrix(notMulti);

            Graph multiGraph = new Graph(multiMatrix);
            Graph notMultiGraph = new Graph(notMultiMatrix);

            Assert.AreEqual(multiGraph.isMultigraphByAdjacencyMatrix(), true, "mult");
            Assert.AreEqual(notMultiGraph.isMultigraphByAdjacencyMatrix(), false, "not mult");
        }
    }
}
