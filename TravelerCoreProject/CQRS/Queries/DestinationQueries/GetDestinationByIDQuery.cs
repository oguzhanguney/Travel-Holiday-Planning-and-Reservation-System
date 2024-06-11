namespace TravelerCoreProject.CQRS.Queries.DestinationQueries
{
    public class GetDestinationByIDQuery
    {
        public GetDestinationByIDQuery(int id)
        {
            this.id = id;
        }

        //gönderecegimiz parametreyi tanımalayalım.
        public int id { get; set; }
    }
}
