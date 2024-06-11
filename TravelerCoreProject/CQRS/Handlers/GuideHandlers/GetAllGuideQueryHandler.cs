using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelerCoreProject.CQRS.Queries.GuideQueries;
using TravelerCoreProject.CQRS.Results.GuideResults;

namespace TravelerCoreProject.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler:IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }
        //handle metodunu yazmayacagız.mediatR miras aldıracagız.
        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                Name = x.Name,
                GuideId = x.GuideId,
                Description = x.Description,
                Image = x.Image
            }).AsNoTracking().ToListAsync();
        }
    }
}
