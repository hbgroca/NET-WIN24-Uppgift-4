using Business.Models;

namespace Business.Interfaces
{
    public interface IStatusServices
    {
        Task<IEnumerable<Status>> GetAllAsync();
    }
}