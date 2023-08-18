using BtkAkademi.Web.Models;

namespace BtkAkademi.Web.Services.IServices
{
    public interface IMessageService
    {
        Task<List<T>> GetMessages<T>();
    }
}
