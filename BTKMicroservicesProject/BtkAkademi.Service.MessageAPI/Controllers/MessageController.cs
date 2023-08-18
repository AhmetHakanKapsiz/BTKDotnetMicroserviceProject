using BtkAkademi.Service.MessageAPI.DbContexts;
using BtkAkademi.Service.MessageAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademi.Service.MessageAPI.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private ApplicationDbContext _context;

        public MessageController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        [HttpGet]
        public async Task<List<Message>> GetMessages()
        {
            var messages = await _context.Messages.ToListAsync();
            return messages;
        }
    }
}
