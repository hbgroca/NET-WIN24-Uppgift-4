using Business.Factories;
using Data.Entities;

namespace Business_Test.Factories;

public class StatusFactory_Test
{
    [Fact]
    private void Create_NullEntity_ReturnsNull()
    {
        // Arrange
        StatusEntity entity = null;

        // Act
        var result = StatusFactory.Create(entity);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    private void Create_ValidEntity_ReturnsStatus()
    {
        // Arrange
        var entity = new StatusEntity
        {
            Id = 1,
            StatusDescription = "Test"
        };
        // Act
        var result = StatusFactory.Create(entity);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(entity.Id, result.Id);
        Assert.Equal(entity.StatusDescription, result.StatusDescription);
    }
}
