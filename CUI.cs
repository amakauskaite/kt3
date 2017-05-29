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
        char name, name1, name2;
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
                    try
                    {
                        name = char.Parse(System.Console.ReadLine());

                        if (!graph.routers.ContainsKey(name))
                            graph.addRouter(new Router(name), graph);
                        else
                            Console.WriteLine("This router already exists");

                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }
                case 3:
                    Console.WriteLine("Please, write the name of router (1 letter only:)");
                    try
                    {
                    name = char.Parse(System.Console.ReadLine());

                    if (graph.routers.ContainsKey(name))
                        graph.deleteRouter(new Router(name), graph);
                    else
                        Console.WriteLine("This router doesn't exist");

                    break;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }
                    
                case 4:
                    try
                    {
                        Console.WriteLine("Name of router 1:");
                        char name1 = char.Parse(System.Console.ReadLine());
                        Console.WriteLine("Name of router 2:");
                        char name2 = char.Parse(System.Console.ReadLine());
                        Console.WriteLine("Distance between the two:");
                        int dist = int.Parse(System.Console.ReadLine());

                        if (graph.routers.ContainsKey(name1) && graph.routers.ContainsKey(name2))
                            graph.addLink(name1, name2, dist, graph);
                        else
                            Console.WriteLine("Whoopsie, something went wrong");

                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }
                case 5:
                    try
                    {
                        Console.WriteLine("Name of router 1:");
                        name1 = char.Parse(System.Console.ReadLine());
                        Console.WriteLine("Name of router 2:");
                        name2 = char.Parse(System.Console.ReadLine());
                        if (graph.routers.ContainsKey(name1) && graph.routers.ContainsKey(name2))
                            graph.deleteLink(name1, name2, graph);
                        else
                            Console.WriteLine("Whoopsie, something went wrong");

                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }
                case 6:
                    try
                    {
                        Console.WriteLine("Name of router:");
                        name = char.Parse(System.Console.ReadLine());
                        graph.routers[name].writeNeighbours();

                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }
                case 7:
                    try
                    {
                        Console.WriteLine("Name of router:");
                        name = char.Parse(Console.ReadLine());
                        graph.routers[name].fillTable(graph);
                        graph.routers[name].writeTable(graph);

                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }
                case 8:
                    try
                    {
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
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input");
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
