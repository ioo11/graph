using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_1
{
    public class Graph
    {
        private IncidentMatrix incidentMatrix;
        private AdjacencyMatrix adjacencyMatrix;
        private Vertex[] vertices;

        // TODO : constructor by incident matrix
        public Graph(IncidentMatrix matrix)
        {
            incidentMatrix = matrix;
            // todo: init adjacencyMatrix
        }

        // TODO : constructor by adjacency matrix
        public Graph(AdjacencyMatrix matrix)
        {
            adjacencyMatrix = matrix;
            // todo: init incidenceMatrix
        }

        public bool isOrientedByAdjacencyMatrix()
        {
            return adjacencyMatrix.isOriented();
        }

        public bool isPseudographByAdjacencyMatrix()
        {
            return adjacencyMatrix.isPseudograph();
        }

        public bool isMultigraphByAdjacencyMatrix()
        {
            return adjacencyMatrix.isMultigraph();
        }
    }

    public class AdjacencyMatrix
    {
        private int[,] matrix;
        public int Size;

        public AdjacencyMatrix(int[,] matrix)
        {
            this.matrix = matrix;
            this.Size = matrix.GetLength(0);
        }

        public bool isOriented()
        {
            for (int row = 1; row < Size; row++)
                for (int col = 0; col < row; col++)
                    if (this.matrix[row, col] != this.matrix[col, row])
                        return true;
            return false;
        }

        public bool isPseudograph()
        {
            for (int row = 0; row < Size; row++)
                if (this.matrix[row, row] != 0)
                    return true;
            return false;
        }

        public bool isMultigraph()
        {
            for (int row = 0; row < Size; row++)
                for (int col = 0; col < Size; col++)
                    if (matrix[row, col] > 1)
                        return true;
            return false;
        }

        public int[] getLineOnPosition(int position)
        {
            int[] line = new int[Size];
            for (int i = 0; i < Size; i++)
                line[i] = matrix[position, i];
            return line;
        }
    }

    // TODO : adjacency matrix
    public class  IncidentMatrix
    {
        private int[,] matrix;

        public IncidentMatrix(int[,] matrix)
        {
            this.matrix = matrix;
        }
    }

    public class Vertex
    {
        private Vertex[] _incidentVertices;
        private int _vertexDegree;
        private int _numberOfLoops;
        private bool _isIsolated;
        private bool _isLeaf;


        //todo: construct(IncidentVertices): 

        public Vertex[] IncidentVertices
        {
            get
            {
                return _incidentVertices;
            }
            // TODO: private set
            set
            {
                _incidentVertices = value;
                _numberOfLoops = countLoopsOnVertex(this);
                // every loop is counted twice in vertex degree
                _vertexDegree = _incidentVertices.Length + _numberOfLoops;
                _isIsolated = (_vertexDegree - 2*_numberOfLoops) == 0 ? true : false;
                _isLeaf = (_vertexDegree - 2*_numberOfLoops) == 1 ? true : false;
            }
        }

        private int countLoopsOnVertex(Vertex vertex)
        {
            int numberOfLoops = 0;
            foreach(Vertex i in vertex._incidentVertices)
                if (i == this)
                    numberOfLoops++;
            return numberOfLoops;
        }

        public int VertexDegree
        {
            get
            {
                if (_incidentVertices == null)
                    throw new ApplicationException("incident vertices is not defined");
                else
                    return _vertexDegree;
            }
        }

        public int NumberOfLoops
        {
            get
            {
                if (_incidentVertices == null)
                    throw new ApplicationException("incident vertices is not defined");
                else
                    return _numberOfLoops;
            }
        }
        public bool IsIsolated
        {
            get
            {
                if (_incidentVertices == null)
                    throw new ApplicationException("incident vertices is not defined");
                else
                    return _isIsolated;
            }
        }
        public bool IsLeaf
        {
            get
            {
                if (_incidentVertices == null)
                    throw new ApplicationException("incident vertices is not defined");
                else
                    return _isLeaf;
            }
        }
    }
}
