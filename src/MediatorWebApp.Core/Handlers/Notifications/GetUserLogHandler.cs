namespace MediatorWebApp.Core.Handlers.Notifications
{
    using MediatorWebApp.Core.Models;
    using MediatR;

    internal class GetUserLogHandler : INotificationHandler<UserGetNotification>
    {
        public GetUserLogHandler()
        {

        }
        public async Task Handle(UserGetNotification notification, CancellationToken cancellationToken)
        {
            foreach (var item in notification?.Users)
            {
                Console.WriteLine($"User with ID: {item?.Id} was requested");
            }
            
            await Task.CompletedTask;
        }
    }
}
