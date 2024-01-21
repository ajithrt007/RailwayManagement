using RailwayManagement.Utils;

namespace RailwayManagement.Services
{
    class TrainServices
    {
        public static void ViewTrains()
        {
            using (var context = new RailwayContext())
            {
                try
                {
                    var trains = context.Trains.ToList();
                    Utilities.LineBreak();
                    foreach (var train in trains)
                    {
                        Console.WriteLine($"Train Name: {train.TrainName}");
                        Console.WriteLine($"Number: {train.TrainNumber}");
                        Console.WriteLine($"From: {train.From}");
                        Console.WriteLine($"To: {train.To}");
                        Console.WriteLine($"Distance: {train.Distance}");
                        Console.WriteLine($"Time: {train.Duration}");
                        Console.WriteLine($"Exception: {train.Exception}");
                        Utilities.LineBreak();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}. Connection refused. Contact Administrator...");
                }
            }
        }
    }
}