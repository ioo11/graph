using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] notOriented = { { 0, 1, 0, 0 }, { 1, 1, 0, 1 }, { 0, 0, 0, 0 }, { 0, 1, 0, 0 } };
            int[,] pseudo = { { 0, 1, 0, 0 }, { 1, 1, 0, 1 }, { 1, 0, 0, 0 }, { 0, 1, 0, 0 } };
            AdjacencyMatrix pseudoMatrix = new AdjacencyMatrix(pseudo);
            Graph pseudoGraph = new Graph(pseudoMatrix);
           
        }
    }
}
