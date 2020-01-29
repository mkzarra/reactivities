using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using Activity = Domain.Activity;

namespace Application.Activities
{
  public class List
  {
    public class Query : IRequest<List<Activity>> {}
    public class Handler : IRequestHandler<Query, List<Activity>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
          _context = context;
      }

      public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
      {
        var Activities = await _context.Activities.ToListAsync();

        return Activities;
      }
    }
  }
}