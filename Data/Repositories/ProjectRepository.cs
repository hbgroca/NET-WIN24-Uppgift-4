using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectRepository : BaseRepository<ProjectEntity>, IProjectRepository
{
    private readonly DataContext _context;

    public ProjectRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}
