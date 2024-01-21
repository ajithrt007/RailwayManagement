using RailwayManagement.Entities;
using RailwayManagement.Utils;

namespace RailwayManagement.Services
{
    class TicketService
    {
        public static int BookTickets()
        {
            using (var context = new RailwayContext())
            {
                try
                {
                    Utilities.LineBreak();
                    string passengerUsername;
                    Console.WriteLine("Enter Passenger username:");
                    passengerUsername = Console.ReadLine();
                    int? passengerId = context.Passengers.Where(p => p.Username == passengerUsername).Select(p => p.PassengerId).FirstOrDefault();
                    
                    if(passengerId == 0)
                    {
                        Console.WriteLine("No passenger found!!");
                        return 0;
                    }

                    var fromLocations = context.Trains.Select(t => t.From).Distinct().ToList();

                    Utilities.LineBreak();
                    Console.WriteLine("Choose Starting Location");
                    Utilities.LineBreak();

                    for (int i = 0; i < fromLocations.Count; i++)
                    {
                        Console.WriteLine($"{i+1}, {fromLocations[i]}");
                    }

                    Console.WriteLine("Enter From:");
                    var from = Convert.ToInt32(Console.ReadLine());

                    var toLocations = context.Trains.Where(t => t.From == fromLocations[from - 1]).Select(t => t.To).Distinct().ToList();
                    
                    Utilities.LineBreak();
                    Console.WriteLine("Choose Destination");
                    Utilities.LineBreak();

                    for (int i = 0; i < toLocations.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}, {toLocations[i]}");
                    }

                    Console.WriteLine("Enter To:");
                    var to = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Day of Travel(!!not date):");
                    var day = Console.ReadLine();


                    var availableTrains = context.Trains.Where(t => t.From == fromLocations[from - 1] && t.To == toLocations[to - 1] && t.Exception != day).Select(t => new { t.Duration, t.TrainName, t.TrainId, t.Distance }).ToList();

                    Utilities.LineBreak();
                    Console.WriteLine("Choose from Available Trains");
                    Utilities.LineBreak();

                    for (int i = 0; i < availableTrains.Count; i++)
                    {
                        Console.WriteLine($"Train Name: {availableTrains[i].TrainName}");
                        Console.WriteLine($"Distance: {availableTrains[i].Distance}");
                        Console.WriteLine($"Time: {availableTrains[i].Duration}");
                        Utilities.LineBreak();
                    }

                    Console.WriteLine("Choose trains:");
                    var trainOption = Convert.ToInt32(Console.ReadLine());

                    var selectedTrainName = availableTrains[trainOption - 1].TrainName;
                    var selectedTrainId = availableTrains[trainOption - 1].TrainId;
                    DateTime current = DateTime.Now;
                    decimal ticketCost = Utilities.CalculateTicketCost(availableTrains[trainOption - 1].Distance);

                    var ticket = new Ticket { From = fromLocations[from - 1], To = toLocations[to - 1], PassengerId = passengerId.Value, TrainId = selectedTrainId, TrainName = selectedTrainName, TicketTime = current, TicketCost = ticketCost };
                    
                    context.Tickets.Add(ticket);
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}. Contact Administrator...");
                }
            }
            return 0;

        }
        public static int CancelTickets()
        {
            Console.WriteLine("Enter Ticket id:");
            var ticketId = Convert.ToInt32(Console.ReadLine());
            
            using(var context = new RailwayContext())
            {
                try
                {
                    var ticketToBeDeleted = context.Tickets.Where(t => t.TicketId == ticketId).FirstOrDefault();
                    if (ticketToBeDeleted != null)
                    {
                        context.Tickets.Remove(ticketToBeDeleted);
                        context.SaveChanges();
                        return 1;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}. Contact Administrator...");
                }
            }
            return 0;
        }
        public static void ViewTickets(int? passengerId)
        {
            Utilities.LineBreak();
            using (var context = new RailwayContext())
            {
                try
                {
                    var tickets = context.Tickets.Where(t => passengerId == null || t.PassengerId == passengerId).ToList();
                    foreach (var ticket in tickets)
                    {
                        Console.WriteLine($"Ticket Id: {ticket.TicketId}");
                        Console.WriteLine($"Train Name: {ticket.TrainName}");
                        Console.WriteLine($"From: {ticket.From}");
                        Console.WriteLine($"Destination: {ticket.To}");
                        Console.WriteLine($"Cost: {ticket.TicketCost}");
                        Console.WriteLine($"Time: {ticket.TicketTime}");
                        Utilities.LineBreak();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}. Contact Administrator...");
                }
            }
        }
    }
}