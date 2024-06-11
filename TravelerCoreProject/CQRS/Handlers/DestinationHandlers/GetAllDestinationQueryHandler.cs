using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TravelerCoreProject.CQRS.Queries.DestinationQueries;
using TravelerCoreProject.CQRS.Results.DestinationResults;

namespace TravelerCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        //listeleme:
        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                //atamalar:
                id = x.DestinationID,
                capacity = x.Capacity,
                city = x.City,
                daynight = x.DayNight,
                price = x.Price
            }).AsNoTracking().ToList();
            return (values);
        }
    }
}
