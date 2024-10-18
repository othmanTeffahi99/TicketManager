using Moq;
using Shouldly;
using TicketManager.Domain.Repositories;
using Xunit;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace YourNamespace.Tests
{
    public class IRepositoryTests
    {
        private readonly Mock<IRepository<TestEntity>> _mockRepository;

        public IRepositoryTests()
        {
            _mockRepository = new Mock<IRepository<TestEntity>>();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllEntities()
        {
            // Arrange
            var entities = new List<TestEntity>
            {
                new TestEntity { Id = 1, Name = "Test1" },
                new TestEntity { Id = 2, Name = "Test2" }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(entities);

            // Act
            var result = await _mockRepository.Object.GetAllAsync();

            // Assert
            result.ShouldNotBeNull();
            result.Count().ShouldBe(2);
            result.ShouldContain(e => e.Id == 1 && e.Name == "Test1");
            result.ShouldContain(e => e.Id == 2 && e.Name == "Test2");
        }

        [Fact]
        public async Task FindByIdAsync_ShouldReturnCorrectEntity()
        {
            // Arrange
            var entity = new TestEntity { Id = 1, Name = "Test" };
            _mockRepository.Setup(repo => repo.FindByIdAsync(1, It.IsAny<CancellationToken>()))
                .ReturnsAsync(entity);

            // Act
            var result = await _mockRepository.Object.FindByIdAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
            result.Name.ShouldBe("Test");
        }

        [Fact]
        public async Task FindByIdAsync_ShouldReturnNullForNonExistentEntity()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.FindByIdAsync(999, It.IsAny<CancellationToken>()))
                .ReturnsAsync((TestEntity)null);

            // Act
            var result = await _mockRepository.Object.FindByIdAsync(999);

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntityAndReturnIt()
        {
            // Arrange
            var entity = new TestEntity { Id = 1, Name = "Test" };
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<TestEntity>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((TestEntity e, CancellationToken token) => e);

            // Act
            var result = await _mockRepository.Object.AddAsync(entity);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
            result.Name.ShouldBe("Test");
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<TestEntity>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateEntityAndReturnIt()
        {
            // Arrange
            var entity = new TestEntity { Id = 1, Name = "Updated Test" };
            _mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<TestEntity>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((TestEntity e, CancellationToken token) => e);

            // Act
            var result = await _mockRepository.Object.UpdateAsync(entity);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
            result.Name.ShouldBe("Updated Test");
            _mockRepository.Verify(repo => repo.UpdateAsync(It.IsAny<TestEntity>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveEntityAndReturnIt()
        {
            // Arrange
            var entity = new TestEntity { Id = 1, Name = "Test" };
            _mockRepository.Setup(repo => repo.DeleteAsync(It.IsAny<TestEntity>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((TestEntity e, CancellationToken token) => e);

            // Act
            var result = await _mockRepository.Object.DeleteAsync(entity);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
            result.Name.ShouldBe("Test");
            _mockRepository.Verify(repo => repo.DeleteAsync(It.IsAny<TestEntity>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }

    // Test entity class for use in the repository
    public class TestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}