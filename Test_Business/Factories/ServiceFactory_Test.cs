using Business.Factories;
using Data.Entities;

namespace Business_Test.Factories;

public class ServiceFactory_Test
{
    [Fact]
    private void Create_NullEntity_ReturnsNull()
    {
        // Arrange
        ServiceEntity entity = null;

        // Act
        var result = ServiceFactory.Create(entity);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    private void Create_ValidEntity_ReturnsService()
    {
        // Arrange
        var entity = new ServiceEntity
        {
            Id = 1,
            ServiceName = "Test"
        };

        // Act
        var result = ServiceFactory.Create(entity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(entity.Id, result.Id);
        Assert.Equal(entity.ServiceName, result.Name);
    }
}
