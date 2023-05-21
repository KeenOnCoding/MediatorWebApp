namespace MediatorWebApp.Worker.Handlers.Notifications
{
    using MediatR;
    public class AddUserLogHandler : INotificationHandler<AddUserNotification>
    {
        public async Task Handle(AddUserNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"User with ID: {notification?.User?.Id} was added");
            await Task.CompletedTask;
        }
    }
    public class AddUserNotification : INotification
    {
        public User? User { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
