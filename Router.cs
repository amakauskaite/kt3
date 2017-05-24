using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingProtocolImplementation
{
    class Router
    {
        public string name;
        List<Router> neighbours;
        //public string message;



        public Router (string name)
        {
            this.name = name;
        }

    }
}
