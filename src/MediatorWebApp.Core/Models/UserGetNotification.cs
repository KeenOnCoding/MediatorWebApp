namespace MediatorWebApp.Core.Models
{
    internal class UserGetNotification : MediatR.INotification
    {
        public List<User>? Users { get; set; }
    }
}
