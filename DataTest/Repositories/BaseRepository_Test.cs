using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data_Test.Repositories
{
    public class BaseRepository_Test
    {
        // We are using the ProjectRepository to get access to the BaseRepositorys methods
        private readonly DataContext _context;
        private readonly IProjectRepository _projectRepository;

        public BaseRepository_Test()
        {
            // Create new instance of the DbContext
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: $"DB-{Guid.NewGuid()}")
                .Options;

            _context = new DataContext(options);
            _projectRepository = new ProjectRepository(_context);
        }

        // Create a new instance of the ProjectEntity that will be used in the tests
        private readonly ProjectEntity projectEntity = new ProjectEntity
        {
            ProjectName = "Create website for client",
            Description = "Create a website for the client",
            StartDate = new DateOnly(1986, 1, 1),
            EndDate = new DateOnly(2099, 12, 31),
            ServiceCost = 9999,
            EmployeeId = 1,
            Employee = new EmployeeEntity
            {
                Email = "nils@domain.com",
                FirstName = "Nils",
                LastName = "Andersson"
            },
            CustomerId = 1,
            Customer = new CustomerEntity
            {
                Email = "oskar@domain.com",
                FirstName = "Oskar",
                LastName = "Hansson"
            },
            ServiceId = 1,
            Service = new ServiceEntity
            {
                ServiceName = "Web development"
            },
            StatusId = 1,
            Status = new StatusEntity
            {
                StatusDescription = "Ongoing"
            }
        };


        // Using the BaseRepository 
        [Fact]
        public async Task CreateAsync_ShoudAddProjectToDatabase_ShouldReturnProjectEntityWithId_WhenSavedToDB()
        {
            // Act
            var result = await _projectRepository.CreateAsync(projectEntity);

            // Assert
            Assert.NotNull(result);
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnIEnumrableListWithEntities()
        {
            // Arrange
            for (int i = 1; i < 11; i++)
            {
                var entity = projectEntity;
                entity.Id = i;
                _context.Projects.Add(entity);
            await _context.SaveChangesAsync();
            }

            // Act
            var result = await _projectRepository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.Count());
        }


        [Fact]
        public async Task GetAsync_ShouldReturnEntity_UseExpression()
        {
            // Arrange
            // Add 10 entities to the database
            for (int i = 1; i < 11; i++)
            {
                var entity = projectEntity;
                // Set the Id and name to the current iteration
                entity.Id = i;
                entity.ProjectName = $"Project {i}";
                _context.Projects.Add(entity);
                await _context.SaveChangesAsync();
            }

            // Act
            var result = await _projectRepository.GetAsync(robban => robban.ProjectName == "Project 6");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Project 6", result.ProjectName);
        }


        [Fact]
        public async Task GetAllAsync_ShouldReturnEntities_UseExpression()
        {
            // Arrange
            // Add 10 entities to the database
            for (int i = 1; i < 11; i++)
            {
                var entity = projectEntity;
                // Set the Id to the current iteration
                entity.Id = i;
                _context.Projects.Add(entity);
                await _context.SaveChangesAsync();
            }

            // Act
            var result = await _projectRepository.GetAllAsync(e => e.Employee.FirstName == "Nils");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.Count());
        }


        [Fact]
        public async Task UpdateAsync_ShoudReturnUpdatedEntity_WhenSuppliedWithEntity()
        {
            // Arrange
            // Add a new entity to the database
            var result = await _projectRepository.CreateAsync(projectEntity);

            // Act
            projectEntity.ProjectName = "Robbans Webpage Project";
            var updatedResult = _projectRepository.Update(projectEntity);
            var xa = await _projectRepository.GetAsync(p => p.Id == projectEntity.Id);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Robbans Webpage Project", xa.ProjectName);
        }


        [Fact]
        public async Task DeleteAsync_ShoudReturnTrue_WhenSuccessfull()
        {
            // Arrange
            await _projectRepository.CreateAsync(projectEntity);

            // Act
            var result = _projectRepository.Delete(projectEntity);

            // Assert
            Assert.True(result);
        }
    }
}
