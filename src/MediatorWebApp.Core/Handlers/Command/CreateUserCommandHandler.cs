using MediatR;

namespace MediatorWebApp.Core.Handlers.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly ApplicationDbContext _context;

        public CreateUserCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var resutl = await _context.Users.AddAsync(request.User);
            return request.User;
        }
    }
}