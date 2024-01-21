using RailwayManagement.Entities;
using RailwayManagement.Utils;

namespace RailwayManagement.Services
{
    class PassengerServices
    {
        public static int PassengerLogin()
        {
            Console.WriteLine("Passenger Username: ");
            var username = Console.ReadLine();

            Console.WriteLine("Passenger Password: ");
            var password = Console.ReadLine();

            using (var context = new RailwayContext())
            {
                try
                {
                    var currentUser = context.Passengers.Where(p => p.Username == username && p.Password == password).FirstOrDefault();
                    if (currentUser == null)
                    {
                        Console.WriteLine("No such user found !!");
                        return 0;
                    }

                    DateTime current = DateTime.Now;
                    DateTime DOB = currentUser.Dob.ToDateTime(TimeOnly.Parse("10:00 PM"));
                    int age = (int)current.Subtract(DOB).TotalDays / 365;


                    Console.WriteLine($"UserId: {currentUser.PassengerId}");
                    Console.WriteLine($"Name: {currentUser.Name}");
                    Console.WriteLine($"Username: {currentUser.Username}");
                    Console.WriteLine($"Password: {currentUser.Password}");
                    Console.WriteLine($"Age: {age}");

                    Utilities.LineBreak();
                    Console.WriteLine("Tickets Purchased");
                    Utilities.LineBreak();

                    TicketService.ViewTickets(currentUser.PassengerId);

                    return 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}. Connection refused. Contact Administrator...");

                }
            }
            return 0;
        }
        public static int CreatePassenger()
        {
            Console.WriteLine("Passenger Name: ");
            var passengerName = Console.ReadLine();

            Console.WriteLine("Passenger DOB: ");
            var inputDob = Console.ReadLine();
            DateOnly dob = DateOnly.Parse(inputDob);

            Console.WriteLine("Passenger Username: ");
            var username = Console.ReadLine();

            Console.WriteLine("Passenger Password: ");
            var password = Console.ReadLine();

            var Passenger = new Passenger { Username = username, Password = password, Dob = dob, Name = passengerName };

            using (var context = new RailwayContext())
            {
                try
                {
                    context.Passengers.Add(Passenger);                    
                    context.SaveChanges();
                    Utilities.LineBreak();
                    return 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}. Connection refused. Contact Administrator...");
                }
            }
            return 0;
        }
    }
}