namespace TravelerCoreProject.CQRS.Commands.DestinationCommands
{
    public class UpdateDestinationCommand
    {
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string Daynight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }

    }
}
