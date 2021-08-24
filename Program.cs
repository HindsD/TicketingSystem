using System;
using System.IO;
namespace DotNetTicketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;
            do
            {
                Console.WriteLine("1) List all tickets.");
                Console.WriteLine("2) Create new ticket.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] arr = line.Split('|');
                            Console.WriteLine("TicketID: {0}\nSummary: {1}\nStatus: {2}\nPriority: {3}\nSubmitter: {4}\nAssigned: {5}\nWatching: {6}", 
                            arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    StreamWriter sw = new StreamWriter(file);
                    for (int i = 1; i < 10; i++)
                    {
                        Console.WriteLine("Enter a Ticket (Y/N)?");
                        string resp = Console.ReadLine().ToUpper();
                        if (resp != "Y") { break; }
                        Console.WriteLine("Enter the summary of the ticket.");
                        string summary = Console.ReadLine();
                        Console.WriteLine("Enter the current status.");
                        string status = Console.ReadLine();
                        Console.WriteLine("Enter the priority.");
                        string priority = Console.ReadLine();
                        Console.WriteLine("Who submitted the ticket?");
                        string submitter = Console.ReadLine();
                        Console.WriteLine("Who is assigned the ticket?");
                        string assigned = Console.ReadLine();
                        Console.WriteLine("Who is watching?");
                        string watching = Console.ReadLine();
                        sw.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", i, summary, status, priority, submitter, assigned, watching);
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
