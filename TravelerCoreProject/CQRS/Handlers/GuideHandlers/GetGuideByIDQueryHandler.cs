using DataAccessLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelerCoreProject.CQRS.Queries.GuideQueries;
using TravelerCoreProject.CQRS.Results.GuideResults;

namespace TravelerCoreProject.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var values=await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIDQueryResult
            {
                GuideId = values.GuideId,
                Description = values.Description,
                Name = values.Name
            };
        }
    }
}
