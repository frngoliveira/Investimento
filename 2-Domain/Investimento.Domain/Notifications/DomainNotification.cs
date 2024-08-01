namespace Investimento.Domain.Notifications
{
    public class DomainNotification
    {
        public string Message { get; private set; }
        public DomainNotification(string message)
        {
            Message = message;
        }
    }
}
