using MediatorWebApp.Core.Models;
using MediatR;

namespace MediatorWebApp.Core.Handlers.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        public CreateUserCommandHandler(ApplicationDbContext context, IMediator mediator) 
            => (_context,_mediator) = (context,mediator);

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
             await _context.Users.AddAsync(request.User);

            await _context.SaveChangesAsync();
            await _mediator.Publish(new AddUserNotification() { User = request.User });
            
            return request.User;
        }
    }
}