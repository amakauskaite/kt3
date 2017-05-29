using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Graph
    {
        //public Dictionary<char, Dictionary<char,int>> routers = new Dictionary<char, Dictionary<char, int>>();
        public Dictionary<char, Router> routers = new Dictionary<char, Router>();

        public void addRouter (Router r, Graph graph)
        {
            r.fillTable(graph);
            routers.Add(r.name, r);
            
        }

        public void deleteRouter (Router r, Graph graph)
        {
            routers.Remove(r.name);
            //panaikinti direct linkus reik irgi!
            foreach (var router in routers )
            {
                if(router.Value.directLinks.ContainsKey(r.name))
                {
                    router.Value.directLinks.Remove(r.name);
                }
            }
            fillAllTables(graph);
        }

        public void addLink (char r1, char r2, int dist)
        {
            deleteLink(r1, r2);
            routers[r1].directLinks.Add(r2, dist);
            routers[r2].directLinks.Add(r1, dist);
        }

        public void deleteLink (char r1, char r2)
        {
            routers[r1].directLinks.Remove(r2);
            routers[r2].directLinks.Remove(r1);
        }

        public void printGraph ()
        {
            foreach(var r in routers)
            {
                Console.WriteLine("Router {0}", r.Key);
            }
            //TODO: let's print! (hope it works!)
        }

        //pseudo filling, because these routers don't hold know the direct links - at least, doesn't have the newest versions of them
        //JUST IN: NORMAL FILLING~!!
        public void fillAllTables (Graph graph)
        {   
            foreach(var router in routers)
            {
                router.Value.fillTable(graph);   
            }
        }

        public List<char> shortest_path(char start, char finish)
        {
            var previous = new Dictionary<char, char>();
            var distances = new Dictionary<char, int>();
            var nodes = new List<char>();

            List<char> path = null;

            foreach (var router in routers)
            {
                if (router.Key == start)
                {
                    distances[router.Key] = 0;
                }
                else
                {
                    distances[router.Key] = int.MaxValue;
                }

                nodes.Add(router.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == finish)
                {
                    path = new List<char>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in routers[smallest].directLinks)
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            return path;
        }
    }
}
