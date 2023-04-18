namespace DepthFirstSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Graph g = new Graph(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" });
            g.AddEdges(0, new int[] { 1, 2 });
            g.AddEdges(1, new int[] { 0, 3, 4 });
            g.AddEdges(2, new int[] { 0, 3, 5 });
            g.AddEdges(3, new int[] { 1, 2, 4 });
            g.AddEdges(4, new int[] { 1, 5 });
            g.AddEdges(5, new int[] { 2, 3, 4, 7 });
            g.AddEdges(6, new int[] { 7, 8 });
            g.AddEdges(7, new int[] { 5, 6, 8 });
            g.AddEdges(8, new int[] { 6, 7 });
            g.DFS();
        }

        public class Vertex
        {
            public string? Name;

            public bool Visited;

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

            public void AddEdges(int vertexIndex, int[] targets)
            {
                this.Vertices[vertexIndex].VertexLinks = new Edge[targets.Length];
                for (int i = 0; i < targets.Length; i++)
                {
                    this.Vertices[vertexIndex].VertexLinks[i]
                        = new Edge(this.Vertices[vertexIndex], this.Vertices[targets[i]]);
                }
            }

            public void DFS()
            {
                Console.WriteLine("DFS Alg.");
                DFSRecurion(Vertices[0]);
            }
                                            
            private void DFSRecurion(Vertex currentVertex)
            {
                currentVertex.Visited = true;
                Edge[] destinations = currentVertex.VertexLinks;
                for (int i = 0; i < destinations.Length; i++)
                {
                    if (destinations[i].Target.Visited == false)
                    {
                        Console.WriteLine(currentVertex.Name + "-" + destinations[i].Target.Name);
                        DFSRecurion(destinations[i].Target);
                    }
                }

            }


        }
    }
}