namespace RailwayManagement.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public required string TrainName { get; set; }
        public required int TrainId { get; set; }
        public required string From { get; set; }
        public required string To { get; set; }
        public required decimal TicketCost { get; set; }
        public required int PassengerId { get; set; }
        public required DateTime TicketTime { get; set; }
    }
}