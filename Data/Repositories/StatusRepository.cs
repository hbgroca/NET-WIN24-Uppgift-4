using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class StatusRepository : BaseRepository<StatusEntity>, IStatusRepository
    {
        private readonly DataContext _context;
        public StatusRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
