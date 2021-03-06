﻿using System;
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
            CUI ui = new CUI();

            Router a = new Router('a');
            Router b = new Router('b');
            Router c = new Router('c');
            graph.addRouter(a, graph);
            graph.addRouter(b, graph);
            graph.addRouter(c, graph);
            graph.addRouter(new Router('d'), graph);
            graph.addRouter(new Router('e'), graph);
            graph.addLink('a', 'b', 5, graph);
            graph.addLink('a', 'c', 6, graph);
            graph.addLink('b', 'c', 1, graph);
            graph.addLink('b', 'd', 2, graph);
            graph.addLink('d', 'a', 7, graph);
            graph.deleteLink('a', 'd', graph);
            graph.fillAllTables(graph);

            while(true)
            {
                int answer = ui.printCommands();
                ui.switchStatement(answer, graph);
                //could add a timer to renew tables
            }


            /*
             * TODO:
             * *padaryti žinutės persiuntimą
             * *padaryti, kad lentelė būtų automatiškai atnaujinama
             * *padaryti žinutės peržiūrą
             */
             
        }
    }
}
