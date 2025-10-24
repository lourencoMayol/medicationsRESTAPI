using apiTests;
using Application.BusinessLayer.Services;
using Application.Shared.DTOs;

namespace Application.Tests
{
    public class MedicationServiceTests
    {
        private readonly MedicationServiceFake Service;

        public MedicationServiceTests()
        {
            // Initialize the fake service with sample data
            Service = new MedicationServiceFake();
        }

        [Fact]
        public async Task GetByIdAsync_ExistingId_ReturnsMedication()
        {
            // Arrange
            int existingId = 1;

            // Act
            ServiceResponse<MedicationReadDto> result = await Service.GetByIdAsync(existingId);

            // Assert
            Assert.True(result.Success);
            Assert.NotNull(result.Dto);
            Assert.Equal(existingId, result.Dto.MedId);
            Assert.Equal("Aspirin", result.Dto.Name);
            Assert.Equal(10, result.Dto.Quantity);
            Assert.Equal(new DateTime(2025, 1, 1), result.Dto.CreationDate);

        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ReturnsError()
        {
            // Arrange
            int nonExistingId = 99;

            // Act
            ServiceResponse<MedicationReadDto> result = await Service.GetByIdAsync(nonExistingId);

            // Assert
            Assert.False(result.Success);
            Assert.Null(result.Dto);
            Assert.Equal($"Medication with Id {nonExistingId} not found!", result.ErrorMessage);
        }
    }
}
