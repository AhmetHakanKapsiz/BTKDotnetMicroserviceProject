using BtkAkademi.Web.Models;

namespace BtkAkademi.Web.Services.IServices
{
    public interface IMessageService : IBaseService
    {
        Task<T> GetMessages<T>(string token);
    }
}
