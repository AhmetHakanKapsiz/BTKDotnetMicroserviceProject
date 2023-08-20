using BtkAkademi.Service.MessageAPI.Models;
using BtkAkademi.Service.MessageAPI.Repository;
using Microsoft.AspNetCore.SignalR;

namespace BtkAkademi.Service.MessageAPI.Hubs
{
    public class MessageHub : Hub
    {
        private IMessageRepository _repository;
        public MessageHub(IMessageRepository repository) { 
            _repository = repository;
        }

        public async Task SendMessageToAdmin(MessageDto messageDto)
        {
            Message message = await _repository.CreateMessage(messageDto);
            await Clients.All.SendAsync("newMessageToAdmin", message);
            await Clients
                .Client(message.ClientConnectionId)
                .SendAsync("newMessageToUser", message);
        }
        
        public async Task SendMessageToUser(MessageDto messageDto)
        {
            Message message = await _repository.CreateMessage(messageDto);
            string userConnectionId = await _repository.GetUserIdByMessage(message);
            await Clients
                .Client(message.ClientConnectionId)
                .SendAsync("newMessageToAdminFromAdmin", message);
            await Clients
                .Client(userConnectionId)
                .SendAsync("newMessageToUserFromAdmin", message);
        }

        public async Task DeleteConversation(string conversationId)
        {
            await _repository.DeleteConversation(Guid.Parse(conversationId));
            await Clients.All.SendAsync("deleteConversation", conversationId);
        }
    }
}
