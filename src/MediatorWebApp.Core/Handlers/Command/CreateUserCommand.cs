using MediatR;

namespace MediatorWebApp.Core.Handlers.Command
{
    public class CreateUserCommand : IRequest<User>
    {
        public User User { get; set; }
    }
}