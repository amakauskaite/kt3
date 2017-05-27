using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra;

namespace DijikstraConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            Router a = new Router('a');
            Router b = new Router('b');
            Router c = new Router('c');
            graph.addRouter(a);
            graph.addRouter(b);
            graph.addRouter(c);
            graph.addRouter(new Router('d'));
            graph.addRouter(new Router('e'));
            graph.addLink('a', 'b', 5);
            graph.addLink('a', 'c', 6);
            graph.addLink('b', 'c', 1);
            graph.addLink('b', 'd', 2);
            graph.addLink('d', 'a', 7);
            graph.deleteLink('a', 'd');


            //List<char> path = graph.shortest_path('a', 'd');//.ForEach(x => Console.WriteLine(x)); //spausdina kelia atvirkscia tvarka btw
            ////path.Add('a');
            //foreach(var node in path.AsEnumerable().Reverse())
            //{
            //    Console.WriteLine(node);
            //}
            a.fillTable(graph);
            a.writeTable();
            Console.ReadKey();
        }
    }
}
