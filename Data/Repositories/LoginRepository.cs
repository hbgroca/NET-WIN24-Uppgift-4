using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class LoginRepository : BaseRepository<LoginEntity>, ILoginRepository
{
    private readonly DataContext _context;

    public LoginRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}
