using BtkAkademi.Service.Email.Messages;

namespace BtkAkademi.Service.Email.Repository
{
    public interface IEmailRepository
    {
        //Task SendAndLogEmail(UpdatePaymentResultMessage message);
        void SendAndLogEmail(UpdatePaymentResultMessage message);
    }
}
