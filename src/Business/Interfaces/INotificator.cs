using Business.Notifications;

namespace Business.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotificatios();

        void Handle(Notification notification);
    }
}
