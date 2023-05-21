namespace MediatorWebApp.Core.Models
{
    public class AddUserNotification : MediatR.INotification
    {
        public User? User { get; set; }
    }
}
