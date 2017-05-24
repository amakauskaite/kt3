using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingProtocolImplementation
{
    class Link
    {
        public int cost;
        public Router r1;
        public Router r2;

        public Link (Router r1, Router r2, int cost)
        {
            this.r1 = r1;
            this.r2 = r2;
            this.cost = cost;
        }


    }
}
