using BtkAkademi.Service.MessageAPI.Models;

namespace BtkAkademi.Service.MessageAPI.Repository
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessage(MessageDto message);
        Task DeleteConversation(Guid conversationId);
    }
}
