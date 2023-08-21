using Azure;
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
        protected ResponseDto _response;

        public MessageController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _response = new ResponseDto();
        }

        /*
        [HttpGet]
        public async Task<List<Message>> GetMessages()
        {
            var messages = await _context.Messages.ToListAsync();
            return messages;
        }*/

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<Message> messages = await _context.Messages.ToListAsync(); ;
                _response.Result = messages;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
