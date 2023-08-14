using BtkAkademi.MessageBus;

namespace BtkAkademi.Service.PaymentAPI.RabbitMQSender
{
    public interface IRabbitMQPaymentMessageSender
    {
        void SendMessage(BaseMessage baseMessage);
    }
}
