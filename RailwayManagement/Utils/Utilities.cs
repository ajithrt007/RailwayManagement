namespace RailwayManagement.Utils
{
    public class Utilities
    {
        public static void LineBreak()
        {
            Console.WriteLine("---------------------------------------------");
        }
        public static string MSG(int msg)
        {
            var status = msg == 1 ? "Succesfull" : "Failed";
            return status;
        }
        public static decimal CalculateTicketCost(int distance)
        {
            decimal perKmCost = 25;
            decimal fixedCost = 75;
            decimal serviceCharge = 0.75m;
            decimal taxPercentage = 6;
            
            decimal cost = (distance * perKmCost + fixedCost + serviceCharge) * (1 + taxPercentage/100);
            return cost;
        }
    }
}
