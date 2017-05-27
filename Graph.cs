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

        public void addRouter (Router r)
        {
            routers.Add(r.name, r.directLinks);
        }

        public void deleteRouter (Router r)
        {
            routers.Remove(r.name);
        }

        public void addLink (char r1, char r2, int dist)
        {
            routers[r1].Add(r2, dist);
            routers[r2].Add(r1, dist);
        }

        public void deleteLink (char r1, char r2)
        {
            routers[r1].Remove(r2);
            routers[r2].Remove(r1);
        }

        public void printGraph ()
        {
            foreach(var r in routers)
            {
                Console.WriteLine("Key = {0}, Value = {1}", r.Key, r.Value);
            }
            //TODO: let's print! (hope it works!)
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
