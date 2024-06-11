namespace TravelerCoreProject.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        //destination ile ilgili getirmek istedigim properties:
        public int id { get; set; }
        public string city { get; set; }
        public string daynight { get; set; }
        public double price { get; set; }
        public int capacity { get; set; }

    }
}
