namespace RailwayManagement.Entities
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required DateOnly Dob { get; set; }
    }
}