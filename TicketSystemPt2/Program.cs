using System;
using System.IO;

namespace TicketSystemPt2
{
    class Program
    {
        // create a class level instance of logger (can be used in methods other than Main)
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            logger.Info("Program started");

            TicketFile ticketFile = new TicketFile(file);
            string choice;

            do
            {
                Console.WriteLine("1) View Ticket file Summary.");
                Console.WriteLine("2) Create Ticket file.");
                Console.WriteLine("Enter any other key to exit.");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    foreach (Ticket t in ticketFile.Tickets)
                    {
                        Console.WriteLine(t.Output());
                    }
                }
                else if (choice == "2")
                {
                    Ticket ticket = new Ticket();                    

                    Console.WriteLine("Enter a new ticket? (Y/N)");
                    string newTicket = Console.ReadLine().ToUpper();
                    if (newTicket != "Y") { break; }

                    Console.WriteLine("Enter Ticket Summary:");
                    ticket.summary = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Status:");
                    ticket.status = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Priority:");
                    ticket.priority = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Submitter:");
                    ticket.submitter = Console.ReadLine();

                    Console.WriteLine("Ticket Assigned to:");
                    ticket.assigned = Console.ReadLine();

                    string tixWatcher;
                    string theWatchers;
                    do
                    {
                        Console.WriteLine("Is there someone watching this ticket? (Y/N)");
                        tixWatcher = Console.ReadLine();
                        if (!tixWatcher.ToUpper().Equals("Y")) { break; }
                        Console.WriteLine("Who is watching the ticket?");
                        theWatchers = Console.ReadLine();
                        ticket.watchers.Add(theWatchers);
                    } while (tixWatcher.ToUpper().Equals("Y"));
                    ticketFile.AddTicket(ticket);
                }


            } while (choice == "1" || choice == "2");

            logger.Info("Program ended");

        }
    }
}
