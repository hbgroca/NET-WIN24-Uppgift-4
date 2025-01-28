using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class EmployeeRepository : BaseRepository<EmployeeEntity>, IEmployeeRepository
{
    private readonly DataContext _context;
    public EmployeeRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}
