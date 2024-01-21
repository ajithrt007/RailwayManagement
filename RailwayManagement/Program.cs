using RailwayManagement.Seeder;
using RailwayManagement.Services;
using RailwayManagement.Utils;
namespace RailwayManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new RailwayContext())
            {
                if(!context.Trains.Any()) {
                    TrainSeeder.InitializeTrains();
                    Console.WriteLine("Seeded Train data");
                }
            }
            Console.WriteLine("Indian Railways");

            var optionValue = 0;
            string[] featureList = {"Book Tickets", "Cancel Ticket", "Passenger Login", "Passenger Signup", "View Ticket", "View Trains", "Exit" };
            do
            {
                Console.WriteLine("Welcome to Indian Railways");
                Utilities.LineBreak();


                for (int i = 0; i < featureList.Length; i++)
                {
                    Console.WriteLine("{0}, {1}",i+1, featureList[i]);
                }

                Console.WriteLine("Select from options: ");
                optionValue = Convert.ToInt16(Console.ReadLine());

                switch(optionValue)
                {
                    case 1: Console.WriteLine("Book Tickets");
                        var bookingStatus = TicketService.BookTickets();
                        Console.WriteLine($"1 ticket booking {Utilities.MSG(bookingStatus)}");
                        break;
                    case 2: Console.WriteLine("Cancel Tickets");
                        var cancelStatus = TicketService.CancelTickets();
                        Console.WriteLine($"1 ticket cancelling {Utilities.MSG(cancelStatus)}");
                        break;
                    case 3:
                        Console.WriteLine("Passenger Login");
                        var loginStatus = PassengerServices.PassengerLogin();
                        Console.WriteLine($"Login was {Utilities.MSG(loginStatus)}");

                        break;
                    case 4:
                        Console.WriteLine("Passenger Signup");
                        var passengerCreationStatus = PassengerServices.CreatePassenger();
                        Console.WriteLine($"1 Passenger Signup {Utilities.MSG(passengerCreationStatus)}");
                        break;
                    case 5:
                        Console.WriteLine("View Ticket");
                        TicketService.ViewTickets(null);
                        break;
                    case 6:
                        Console.WriteLine("View Trains");
                        TrainServices.ViewTrains();
                        break;
                    case 7:
                        Console.WriteLine("Application Exitting...");
                        break;
                    default: Console.WriteLine("Enter Valid Option");
                        break;
                }
            } while (optionValue != featureList.Length);
        }
    }
}