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
        }
    }
}
