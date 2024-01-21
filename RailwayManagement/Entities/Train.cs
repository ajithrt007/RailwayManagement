namespace RailwayManagement.Entities
{
    public class Train
    {
        public int TrainId { get; set; }
        public required string TrainNumber { get; set; }
        public required string TrainName { get; set; }
        public required string From { get; set; }
        public required string To { get; set; }
        public required string Exception { get; set; }
        public required int Distance { get; set; }
        public required string Duration { get; set; }
    }
}