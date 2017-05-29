using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra;

namespace DijikstraConsole
{
    class CUI
    {
        public int printCommands()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Hello, please choose one of the following:");
            Console.WriteLine("1 - list of all routers");
            Console.WriteLine("2 - add router");
            Console.WriteLine("3 - delete router");
            Console.WriteLine("4 - add link");
            Console.WriteLine("5 - delete link");
            Console.WriteLine("6 - view router and his neighbors");
            Console.WriteLine("7 - view routing table of router");
            Console.WriteLine("8 - see message path");
            Console.WriteLine("9 - bye bye");
            Console.ResetColor();
            try
            {
                return int.Parse(System.Console.ReadLine());
            }
            
            catch
            {
                return 0;
            }

        }

        public void switchStatement(int answer, Graph graph)
        {
            switch(answer)
            {
                case 1:
                    graph.printGraph();

                    break;
                case 2:
                    Console.WriteLine("Please, write the name of router (1 letter only:)");
                    char name = char.Parse(System.Console.ReadLine());

                    if (!graph.routers.ContainsKey(name))
                        graph.addRouter(new Router(name), graph);
                    else
                        Console.WriteLine("This router already exists");

                    break;
                case 3:
                    Console.WriteLine("Please, write the name of router (1 letter only:)");
                    name = char.Parse(System.Console.ReadLine());

                    if (graph.routers.ContainsKey(name))
                        graph.deleteRouter(new Router(name), graph);
                    else
                        Console.WriteLine("This router doesn't exist");

                    break;
                case 4:
                    Console.WriteLine("Name of router 1:");
                    char name1 = char.Parse(System.Console.ReadLine());
                    Console.WriteLine("Name of router 2:");
                    char name2 = char.Parse(System.Console.ReadLine());
                    Console.WriteLine("Distance between the two:");
                    int dist = int.Parse(System.Console.ReadLine());

                    if (graph.routers.ContainsKey(name1) && graph.routers.ContainsKey(name2))
                        graph.addLink(name1, name2, dist);
                    else
                        Console.WriteLine("Whoopsie, something went wrong");

                    break;
                case 5:
                    Console.WriteLine("Name of router 1:");
                    name1 = char.Parse(System.Console.ReadLine());
                    Console.WriteLine("Name of router 2:");
                    name2 = char.Parse(System.Console.ReadLine());
                    if (graph.routers.ContainsKey(name1) && graph.routers.ContainsKey(name2))
                        graph.deleteLink(name1, name2);
                    else
                        Console.WriteLine("Whoopsie, something went wrong");

                    break;
                case 6:
                    Console.WriteLine("Name of router:");
                    name = char.Parse(System.Console.ReadLine());
                    graph.routers[name].writeNeighbours();

                    break;
                case 7:
                    Console.WriteLine("Name of router:");
                    name = char.Parse(System.Console.ReadLine());
                    graph.routers[name].fillTable(graph);
                    graph.routers[name].writeTable();

                    break;
                case 8:
                    Console.WriteLine("Name of router 1:");
                    name1 = char.Parse(System.Console.ReadLine());
                    Console.WriteLine("Name of router 2:");
                    name2 = char.Parse(System.Console.ReadLine());
                    try
                    {
                        var path = graph.shortest_path(name1, name2);
                        path.Reverse();
                        System.Console.WriteLine("~Path (if there is one):~");
                        path.ForEach(x => Console.WriteLine(x));
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("The posibility, that you did something wrong, is high in this one m8");
                        break;
                    }
                   
                case 9:
                    Console.WriteLine("bye bye~~");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong input, try again lololol");

                    break;
            }

        }
    }
}
