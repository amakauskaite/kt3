using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingProtocolImplementation
{
    class Calculation
    {
        //cia turetu buti listai visu routeriu ir visu jungciu tarp ju >:3
        public List<Router> Routers = new List<Router>(); //kazkada kazkaip reik uzpildyt siuos listus!!!!!
        public List<Link> Links = new List<Link>();


        public List<Router> VisitedRouters = new List<Router>();
        public Dictionary<Router, Dictionary<int, Router>> SmallestCost = new Dictionary<Router, Dictionary<int, Router>>();
        Router previous;
        
        

        public void Djisktra(Router r)
        {
            fillDictionary();
            VisitedRouters.Add(r);
            foreach(Router router in Routers)
            {
                SmallestCost[router] = linkExists(r, router); 
            }

            int miniCount = 1; //because one router is already visited!

            while (VisitedRouters.Count != miniCount)
            {
                SmallestCost.OrderBy(cost => cost.Value);
                var first = SmallestCost.First();
                if (!VisitedRouters.Contains(first.Key))
                {
                    previous = VisitedRouters.Last();
                    VisitedRouters.Add(first.Key);
                }

                foreach(Router router in Routers)
                {
                    SmallestCost[router] = Math.Min(SmallestCost[router], linkExists(VisitedRouters.Last(), router) + linkExists(previous, VisitedRouters.Last()));
                }

                miniCount++;
            }
        }

        public void fillDictionary()
        {
            foreach (Router r in Routers)
            {
                SmallestCost.Add(r, int.MaxValue);
            }
        }

        public int linkExists(Router r1, Router r2)
        {
            foreach(Link link in Links)
            {
                if (r1.name == r2.name)
                    return 0;
                if (link.r1.name == r1.name && link.r2.name == r2.name || link.r1.name == r2.name && link.r2.name == r1.name)
                    return link.cost;
            }
            return int.MaxValue;
        }

        


    }
}
