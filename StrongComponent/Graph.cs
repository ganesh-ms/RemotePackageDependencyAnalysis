///////////////////////////////////////////////////////////////////////////////////////////////////
// Graph.cs     - This package is the Graph.cs                                                   //
//                It Provides code to find the strongest componed                                //
//                in the given graph                                                             //
// version      - 1.0                                                                            //
// Language     - C#,Visual Studio 2017                                                          //
// Platform     - Macbook Pro ,Windows 10                                                        //
// Application  - Stronges Component Analysis                                                    //
//                                                                                               //
//Source: user623879                                                                             //
//Source Link : https://stackoverflow.com/questions/6643076/tarjan-cycle-detection-help-c-sharp  //                    //
//Author Name: Ganesh Mamatha Sheshappa                                                          //
//SUID : 35888-1097                                                                              //
//Email_Id : gmamatha@syr.edu                                                                    //
//CSE681 - Software Modeling and Analysis, Fall 2018                                             //
///////////////////////////////////////////////////////////////////////////////////////////////////
/*
 * Package Operations:
 * -------------------
 * Demonstrates how to build a Executive for the 
 * Type-Based Package Dependency Analysis
 * 
 * Required Files:
 * -------------------
 *   None
 *   
 * Maintenance History:
 * --------------------
 * ver 1.0 : 07 Nov 2018
 * - first release
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace StrongComponent
{
    public class Graph
    {
        public static Dictionary<int,string> FileNamesGraph = new Dictionary<int,string>();
        public static List<string> filesGraph { get; set; }
        public static void setGraphDictionary()
        {
            int fileCount = 0;
            foreach (string file in filesGraph)
            {
                FileNamesGraph.Add(fileCount, System.IO.Path.GetFileName(file));
                fileCount++;
            }
        }

        public static List<string> filesGraphs = new List<string>();
        public static int filenumber = new int();
        public static List<Vertex> VertexList = new List<Vertex>();
        public static List<Vertex> graph_nodes = new List<Vertex>();
        public static void setGraphNodes()
        {
            graph_nodes = new List<Vertex>();
        }
        public static void setVertex()
        {
            VertexList = new List<Vertex>(filenumber);
        }
        public static void setGraph()
        {
            for (int i = 0; i < filesGraphs.Count(); i++)
            {
                var v = new Vertex() { Id = i };
                VertexList.Add(v);
            }
        }
        public static void setDependency(int parent,int child)
        {
            VertexList[parent].Dependencies.Add(VertexList[child]);
        }
        public static void addGraph()
        {
            for (int i = 0; i < filesGraphs.Count(); i++)
            {
                graph_nodes.Add(VertexList[i]);
            }
        }
        public static void displayStrongComponent()
        {
            var tcd = new TarjanCycleDetectStack();
            var cycle_list = tcd.DetectCycle(graph_nodes);
            Console.WriteLine("  There are {0} strong component in the graph",cycle_list.Count);
            Console.WriteLine("  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            for(int i =0; i < cycle_list.Count;i++)
            {
                Console.WriteLine("  {0} Strong Component is", i+1);
                Console.WriteLine("  -------------------------");
                for(int j = 0 ; j< cycle_list[i].Count;j++)
                {
                    var myKey = FileNamesGraph[cycle_list[i][j].Id];
                    Console.WriteLine("  "+myKey);
                }
            }
        }
        public List<Vertex> vertexList { get; set; }
        public List<Vertex> inputFiles
        {
            get{
                return this.vertexList;
            }
            set{
                vertexList = new List<Vertex>(inputFiles.Count());
                for (int i = 0; i < inputFiles.Count(); i++)
                {
                    this.vertexList[i].Id = i;
                }
            }

        }
        public void Write()
        {
            Console.WriteLine("Strongest Componet");
        }
        public class MyStack :  Vertex
        {
            List<Vertex> VertexStack = new List<Vertex>();
            public void push(Vertex v)
            {
                VertexStack.Add(v);
            }
            public Vertex pop()
            {
                Vertex PopingVertex;
                int listSize = VertexStack.Count();
                PopingVertex = VertexStack[listSize - 1];
                VertexStack.RemoveAt(listSize - 1);
                return PopingVertex;
            }
            public bool Contains(Vertex v)
            {
                return (VertexStack.Contains(v)) ? true : false;
            }
        }
        public class Vertex
        {
            public int Id { get; set; }
            public int Index { get; set; }
            public int Lowlink { get; set; }

            public HashSet<Vertex> Dependencies { get; set; }
            public Vertex()
            {
                Id = -1;
                Index = -1;
                Lowlink = -1;
                Dependencies = new HashSet<Vertex>();
            }
            public override string ToString()
            {
                return string.Format("Vertex Id {0}", Id);
            }

            public override int GetHashCode()
            {
                return Id;
            }
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                Vertex other = obj as Vertex;
                if (other == null)
                    return false;
                return Id == other.Id;
            }
        }
        public class TarjanCycleDetectStack
        {
            protected List<List<Vertex>> _StronglyConnectedComponents;
            MyStack _Stack = new MyStack();
            protected int _Index;

            public List<List<Vertex>> DetectCycle(List<Vertex> graph_nodes)
            {
                _StronglyConnectedComponents = new List<List<Vertex>>();

                _Index = 0;
                _Stack = new MyStack();

                foreach (Vertex v in graph_nodes)
                {
                    if (v.Index < 0)
                    {
                        StronglyConnect(v);
                    }
                }

                return _StronglyConnectedComponents;
            }

            private void StronglyConnect(Vertex v)
            {
                v.Index = _Index;
                v.Lowlink = _Index;

                _Index++;
                _Stack.push(v);

                foreach (Vertex w in v.Dependencies)
                {
                    if (w.Index < 0)
                    {
                        StronglyConnect(w);
                        v.Lowlink = Math.Min(v.Lowlink, w.Lowlink);
                    }
                    else if (_Stack.Contains(w))
                    {
                        v.Lowlink = Math.Min(v.Lowlink, w.Index);
                    }
                }

                if (v.Lowlink == v.Index)
                {
                    List<Vertex> cycle = new List<Vertex>();
                    Vertex w;

                    do
                    {
                        w = _Stack.pop();
                        cycle.Add(w);
                    } while (v != w);

                    _StronglyConnectedComponents.Add(cycle);
                }
            }
        }
    }
#if (TEST_GRAPH)
    class TestGraph
    {
        static void setGraphInitially()
        {
            Graph testGraph = new Graph();
            List<Graph.Vertex> graph_nodes = new List<Graph.Vertex>();
            Graph.Vertex v1 = new Graph.Vertex() { Id = 1 };
            Graph.Vertex v2 = new Graph.Vertex() { Id = 2 };
            Graph.Vertex v3 = new Graph.Vertex() { Id = 3 };
            v1.Dependencies.Add(v2);
            v2.Dependencies.Add(v3);
            v3.Dependencies.Add(v1);
            graph_nodes.Add(v1);
            graph_nodes.Add(v2);
            graph_nodes.Add(v3);
            var tcd = new Graph.TarjanCycleDetectStack();
            var cycle_list = tcd.DetectCycle(graph_nodes);
            
        }
        static void Main()
        {
            setGraphInitially();
        }

}
#endif
}
