using DataAccessLayer.Concrete;
using TravelerCoreProject.CQRS.Queries.DestinationQueries;
using TravelerCoreProject.CQRS.Results.DestinationResults;

namespace TravelerCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }

        //paramterye göre veri listeleme:
        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var values=_context.Destinations.Find(query.id);
            return new GetDestinationByIDQueryResult
            {
                DestinationID = values.DestinationID,
                City = values.City,
                Daynight = values.DayNight,
                Price=values.Price,
                Capacity=values.Capacity
            };
        }
    }
}
