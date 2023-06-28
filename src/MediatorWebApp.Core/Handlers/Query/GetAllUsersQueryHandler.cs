using Dapper;
using MediatorWebApp.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorWebApp.Core.Handlers.Query
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly DapperContext _dapperContext;

        public GetAllUsersQueryHandler(ApplicationDbContext context, IMediator mediator, DapperContext dapperContext)
            => (_context, _mediator, _dapperContext) = (context, mediator, dapperContext);


        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Users.ToListAsync();
            //var result = (await GetCompanies()).ToList();
            await _mediator.Publish(new UserGetNotification() { Users = result });
            return result;
        }
        public async Task<IEnumerable<User>> GetCompanies()
        {
            var query = "SELECT * FROM Users";
            using (var connection = _dapperContext.CreateConnection())
            {
                var companies = await connection.QueryAsync<User>(query);
                return companies;
            }
        }
        public async Task<List<User>> GetAllUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                //var query = $"SELECT * FROM Users";
                return await _context.Users
               .FromSql($"SELECT * FROM Users")
               .ToListAsync();
            }
        }
    }
}