using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class UserProjectsRepository : BaseRepository<UserProjectsEntity>, IUserProjectsRepository
{
    private readonly DataContext _context;

    public UserProjectsRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}