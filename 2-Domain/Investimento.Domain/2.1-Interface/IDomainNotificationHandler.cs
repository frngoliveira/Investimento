using Investimento.Domain.Notifications;

namespace Investimento.Domain._2._1_Interface
{
    public interface IDomainNotificationHandler
    {
        bool HasNotifications();
        List<DomainNotification> GetNotifications();
        void Handle(DomainNotification notification);
        void Handle(string notification);
    }
}
