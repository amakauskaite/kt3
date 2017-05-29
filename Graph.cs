using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Graph
    {
        public Dictionary<char, Dictionary<char,int>> routers = new Dictionary<char, Dictionary<char, int>>();
        public List<Router> allrouters = new List<Router>();

        public void addRouter (Router r, Graph graph)
        {
            r.fillTable(graph);
            routers.Add(r.name, r.directLinks);
            allrouters.Add(r);
            
        }

        public void deleteRouter (Router r)
        {
            routers.Remove(r.name);
            allrouters.Remove(r);
        }

        public void addLink (char r1, char r2, int dist)
        {
            deleteLink(r1, r2);
            routers[r1].Add(r2, dist);
            routers[r2].Add(r1, dist);
            //fillAllTables(graph);
        }

        public void deleteLink (char r1, char r2)
        {
            routers[r1].Remove(r2);
            routers[r2].Remove(r1);
            //fillAllTables(graph);
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
        public void fillAllTables (Graph graph)
        {   
            foreach(var router in allrouters)
            {
                router.fillTable(graph);   
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

                foreach (var neighbor in routers[smallest])
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
