using MediatR;
using TravelerCoreProject.CQRS.Results.GuideResults;

namespace TravelerCoreProject.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery:IRequest<GetGuideByIDQueryResult>
    {
        public GetGuideByIDQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
