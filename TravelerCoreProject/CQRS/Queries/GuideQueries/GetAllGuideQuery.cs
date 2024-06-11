using MediatR;
using System.Collections.Generic;
using TravelerCoreProject.CQRS.Results.GuideResults;

namespace TravelerCoreProject.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
