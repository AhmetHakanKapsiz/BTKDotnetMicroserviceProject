using BtkAkademi.Service.MessageAPI.DbContexts;
using BtkAkademi.Service.MessageAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademi.Service.MessageAPI.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /*
        public async Task<Message> CreateAdminMessage(AdminMessageDto adminMessageDto)
        {
            var messages = await _context.Messages
                .Where(m => m.ConversationId == Guid.Parse(adminMessageDto.conversationId))
                .ToListAsync();
            var conversationId = messages[0].ConversationId;

            var conversationMessages = await _context.Messages
                .Where(m => m.ConversationId == conversationId)
                .ToListAsync();

            Message message = new Message() {
                ConversationId = conversationId,
                clientConnectionId = conversationMessages[0].clientConnectionId,
                adminConnectionId = adminMessageDto.adminConnectionId,
                MessageContent = adminMessageDto.MessageContent,
                dateTime = DateTime.Now
            };

            _context.Add(message);
            await _context.SaveChangesAsync();

            return message;
        }*/

        public async Task<Message> CreateMessage(MessageDto messageDto)
        {
            Message message;

            if (messageDto.IsAdmin)
            {
                message = new Message
                {
                    ConversationId = Guid.Parse(messageDto.ConversationId),
                    ClientConnectionId = messageDto.ClientConnectionId,
                    Datetime = DateTime.Now,
                    MessageContent = messageDto.MessageContent,
                    IsAdmin = true
                };

            }
            else
            {
                if (messageDto.ConversationId != null)
                {
                    message = new Message
                    {
                        ConversationId = Guid.Parse(messageDto.ConversationId),
                        ClientConnectionId = messageDto.ClientConnectionId,
                        MessageContent = messageDto.MessageContent,
                        Datetime = DateTime.Now,
                        IsAdmin = false
                    };
                }
                else
                {
                    message = new Message
                    {
                        ConversationId = Guid.NewGuid(),
                        ClientConnectionId = messageDto.ClientConnectionId,
                        MessageContent = messageDto.MessageContent,
                        Datetime = DateTime.Now,
                        IsAdmin = false
                    };
                }
            }

            _context.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<string> GetUserIdByMessage(Message message)
        {
            var messages = await _context.Messages
                .Where(m => m.ConversationId == message.ConversationId)
                .ToListAsync();
            return messages[0].ClientConnectionId;
        }

        public async Task DeleteConversation(Guid conversationId)
        {
            var messages = await _context.Messages
                .Where(m => m.ConversationId == conversationId)
                .ToListAsync();
            _context.RemoveRange(messages);
            _context.SaveChanges();
        }
    }
}
