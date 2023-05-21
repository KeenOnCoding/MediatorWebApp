using MediatorWebApp.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorWebApp.Core.Handlers.Query
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public GetAllUsersQueryHandler(ApplicationDbContext context, IMediator mediator)
            => (_context, _mediator) = (context, mediator);


        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Users.ToListAsync();
            await _mediator.Publish(new UserGetNotification() { Users = result });
            return result;
        }
    }
}