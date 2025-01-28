using Business.Models;

namespace Business.Interfaces
{
    public interface IStatusServices
    {
        Task CreateDefaultAsync();
        Task<IEnumerable<Status>> GetAllAsync();
    }
}