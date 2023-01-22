using MediatR;

namespace MediatorWebApp.Core.Handlers.Query
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}