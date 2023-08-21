using BtkAkademi.Web.Models;
using BtkAkademi.Web.Services.IServices;

namespace BtkAkademi.Web.Services
{
    public class MessageService : BaseService, IMessageService
    {
        private readonly IHttpClientFactory _clientFactory;

        public MessageService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> GetMessages<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MessageAPIBase + "/api/messages",
                AccessToken = token
            });
        }

    }
}
