namespace TravelerCoreProject.CQRS.Results.DestinationResults
{
    public class GetDestinationByIDQueryResult
    {
        //güncellemek istediğim verilere ait değerler:
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string Daynight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }

    }
}
