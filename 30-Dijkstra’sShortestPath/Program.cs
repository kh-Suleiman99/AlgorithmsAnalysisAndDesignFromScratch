namespace Dijkstra_sShortestPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" });
            g.AddEdges(0, new int[] { 1, 2, 3 }, new double[] { 2, 4, 3 });
            g.AddEdges(1, new int[] { 4, 5, 6 }, new double[] { 7, 4, 6 });
            g.AddEdges(2, new int[] { 4, 5, 6 }, new double[] { 3, 2, 4 });
            g.AddEdges(3, new int[] { 4, 5, 6 }, new double[] { 4, 1, 5 });
            g.AddEdges(4, new int[] { 7, 8 }, new double[] { 1, 4 });
            g.AddEdges(5, new int[] { 7, 8 }, new double[] { 6, 3 });
            g.AddEdges(6, new int[] { 7, 8 }, new double[] { 3, 3 });
            g.AddEdges(7, new int[] { 9 }, new double[] { 3 });
            g.AddEdges(8, new int[] { 9 }, new double[] { 4 });

            g.Dijkstra();
        }
    }

    
    public class Vertex
    {
        public string? Name;

        public bool Visited;

        public double TotalLength;

        public Vertex? SourceOfTotalLength;

        public Edge[] VertexLinks = null!;
        
    }

    public class Edge
    {
        public double Weight;
        public Vertex Source;
        public Vertex Target;

        public Edge(Vertex source, Vertex target, double weight = 0)
        {
            Source = source;
            Target = target;
            Weight = weight;
        }
    }

    public class Graph
    {
        private int _count = 0;
        public Vertex[] Vertices;
        public Graph(string[] names)
        {
            Vertices = new Vertex[names.Length];
            foreach (string name in names)
            {
                this.Vertices[_count] = new Vertex();
                this.Vertices[_count].Name = name;
                _count++;
            }
        }

        public void AddEdges(int vertexIndex, int[] targets, double[] weights)
        {
            this.Vertices[vertexIndex].VertexLinks = new Edge[targets.Length];
            for (int i = 0; i < targets.Length; i++)
            {
                this.Vertices[vertexIndex].VertexLinks[i]
                    = new Edge(this.Vertices[vertexIndex], this.Vertices[targets[i]], weights[i]);
            }
        }

        public void Dijkstra()
        {
            Edge[] destinations;
            Vertex currentVertex;
            Edge currentEdge;
            Console.WriteLine("Dijkstra Alg.");

            for (int i = 1 ; i < Vertices.Length ; i++ )
            {
                Vertices[i].TotalLength = double.MaxValue;
            }

            for (int i = 0; i < Vertices.Length; i++)
            {
                currentVertex = Vertices[i];  
                destinations = currentVertex.VertexLinks;
                if (destinations is null) continue;
                for(int j = 0 ; j<destinations.Length ; j++)
                {
                    currentEdge = destinations[j];
                    double newLength = currentVertex.TotalLength + currentEdge.Weight;
                    if(newLength < currentEdge.Target.TotalLength)
                    {
                        currentEdge.Target.TotalLength = newLength;
                        currentEdge.Target.SourceOfTotalLength = currentVertex;
                    }
                }
            }

            string path = Vertices[this.Vertices.Length-1].Name!;
            Vertex v = Vertices[this.Vertices.Length - 1];
            while(v.SourceOfTotalLength != null) 
            {
                path = v.SourceOfTotalLength.Name + " - " + path;
                v = v.SourceOfTotalLength;
            }

            Console.WriteLine($"Total length: {Vertices[this.Vertices.Length - 1].TotalLength}");
            Console.WriteLine(path);

        }
    }
}