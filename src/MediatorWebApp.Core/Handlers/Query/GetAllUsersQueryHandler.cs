using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorWebApp.Core.Handlers.Query
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllUsersQueryHandler(ApplicationDbContext context) => _context = context;

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync();
        }
    }
}