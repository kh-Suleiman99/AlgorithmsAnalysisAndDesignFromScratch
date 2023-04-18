using System.Collections;
using System.ComponentModel;

namespace BreadthFirstSearch
{
    internal class Program
    {
        /*
         * 1st Solution
         * 
        static void Main(string[] args)
        {
            int v = 9;
            Hashtable graph = new Hashtable(v);
            graph.Add('A', new char[] { 'B', 'C' });
            graph.Add('B', new char[] { 'E', 'D', 'A' });
            graph.Add('C', new char[] { 'F', 'D', 'A' });
            graph.Add('D', new char[] { 'E', 'F', 'B' });
            graph.Add('E', new char[] { 'F', 'B' });
            graph.Add('F', new char[] { 'E', 'D', 'C','H' });
            graph.Add('G', new char[] { 'H', 'I' });
            graph.Add('H', new char[] { 'G', 'I', 'F' });
            graph.Add('I', new char[] { 'G', 'H'});

            Queue<char> q = new Queue<char>(v);
            q.Enqueue('A');

            Hashtable visited = new Hashtable(v);
            visited.Add('A',true);

            char current_vertex;
            char[] destinations;
            while(q.Count > 0)
            {
                current_vertex = q.Dequeue();
                destinations = (char[]) graph[current_vertex]!;
                for(int i = 0; i< destinations.Length; i++)
                {
                    if (visited.ContainsKey(destinations[i]) == false)
                    {
                        q.Enqueue(destinations[i]);
                        visited.Add(destinations[i], true);
                        Console.WriteLine(current_vertex +"-"+ destinations[i]);
                    }
                }
            }
        }
        */

        ///*2nd Solution
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
            g.BFS();
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
                foreach(string name in names)
                {
                    this.Vertices[_count] = new Vertex();
                    this.Vertices[_count].Name = name;
                    _count++;
                }
            }

            public void AddEdges(int vertexIndex, int[] targets)
            {
                this.Vertices[vertexIndex].VertexLinks = new Edge[targets.Length];
                for(int i =0;i<targets.Length;i++)
                {
                    this.Vertices[vertexIndex].VertexLinks[i] 
                        = new Edge(this.Vertices[vertexIndex], this.Vertices[targets[i]]);
                }
            }

            public void BFS()
            {
                Console.WriteLine("BFS Alg.");
                int v = Vertices.Length;
                Queue<Vertex> q = new Queue<Vertex>(v);
                q.Enqueue(this.Vertices[0]);
                this.Vertices[0].Visited = true;
                Vertex currentVertex;
                Edge[] destinations;

                while (q.Count > 0)
                {
                    currentVertex = q.Dequeue();
                    destinations = currentVertex.VertexLinks;
                    for (int i = 0; i < destinations.Length; i++)
                    {
                        if (destinations[i].Target.Visited == false)
                        {
                            q.Enqueue(destinations[i].Target);
                            destinations[i].Target.Visited = true;
                            Console.WriteLine(currentVertex.Name + "-" + destinations[i].Target.Name);
                        }
                    }
                }
                ResetVertices();
            }

            public void ResetVertices()
            {
                foreach(Vertex v in  this.Vertices)
                {
                    v.Visited = false;
                }
            }
        }
        //*/

    }

}