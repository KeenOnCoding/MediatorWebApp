using MediatorWebApp.Core.Models;
using MediatR;

namespace MediatorWebApp.Core.Handlers.Notifications
{
    public class AddUserLogHandler : INotificationHandler<AddUserNotification>
    {
 
        public AddUserLogHandler()
        {
            
        }
        public async Task Handle(AddUserNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"User with ID: {notification?.User?.Id} was added");
            await Task.CompletedTask;
        }
    }
}
