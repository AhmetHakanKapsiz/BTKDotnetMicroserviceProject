using BtkAkademi.Service.MessageAPI.DbContexts;
using BtkAkademi.Service.MessageAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademi.Service.MessageAPI.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context) { 
            _context = context;
        }

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
        }

        public async Task<Message> CreateMessage(MessageDto messageDto)
        {
            var messages = _context.Messages
                .Where(m => m.clientConnectionId == messageDto.clientConnectionId)
                .ToList();
            Message message;
            if (messages.Count > 0)
            {
                message = new Message
                {
                    ConversationId = messages[0].ConversationId,
                    clientConnectionId = messageDto.clientConnectionId,
                    adminConnectionId = messages[messages.Count - 1].adminConnectionId,
                    MessageContent = messageDto.MessageContent,
                    dateTime = DateTime.Now
                };

            }
            else
            {
                message = new Message
                {
                    ConversationId = Guid.NewGuid(),
                    clientConnectionId = messageDto.clientConnectionId,
                    adminConnectionId = null,
                    MessageContent = messageDto.MessageContent,
                    dateTime = DateTime.Now
                };
            }

            _context.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task DeleteConversation(Guid conversationId)
        {
            var messages = await _context.Messages.Where(m => m.ConversationId == conversationId).ToListAsync();
            _context.RemoveRange(messages);
            _context.SaveChanges();
        }
    }
}
