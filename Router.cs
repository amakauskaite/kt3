using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Router
    {
        public char name;
        public string message = null;
        public Dictionary<char, int> directLinks = new Dictionary<char, int>();
        //{0} - destination name, {1} - next router
        public Dictionary<char, char> shortestPath = new Dictionary<char, char>();

        public Router (char name)
        {
            this.name = name;
            //this.directLinks = new Dictionary<char, int>() { { name, 0} };
        }

        public void fillTable (Graph graph)
        {
            foreach (var variable in graph.routers)
            {
                if (variable.Key != name)
                {
                    List<char> path = graph.shortest_path(name, variable.Key);
                    path.Reverse();
                    if (path.Count != 0)
                        shortestPath.Add(variable.Key, path.First());
                    else shortestPath.Add(variable.Key, '-');
                }
                
            }
            
        }

        public void writeTable()
        {
            Console.WriteLine("Router {0} table is as follows:", name);
            foreach (var element in shortestPath)
            {
                Console.WriteLine("Destintion = {0}, Next router => {1}", element.Key, element.Value);
            }
        }

    }
}
