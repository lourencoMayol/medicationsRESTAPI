using Application.BusinessLayer.Interfaces;
using Application.BusinessLayer.Models;
using Application.BusinessLayer.Services;
using Application.Shared.DTOs;

namespace apiTests
{
    public class MedicationServiceFake : IService<MedicationReadDto, MedicationCreateDto>
    {

        private readonly List<MedicationReadDto> Medications;

        public MedicationServiceFake()
        {
            // Sample in-memory medications
            Medications = new List<MedicationReadDto>()
            {
                new MedicationReadDto { MedId = 1, Name = "Aspirin", Quantity = 10, CreationDate = new DateTime(2025, 1, 1) },
                new MedicationReadDto { MedId = 2, Name = "Ibuprofen", Quantity = 5, CreationDate = new DateTime(2025, 2, 5) },
                new MedicationReadDto { MedId = 3, Name = "Paracetamol", Quantity = 20, CreationDate = new DateTime(2025, 3, 10) }
            };
        }

        public Task<ServiceResponse<MedicationReadDto>> AddAsync(MedicationCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<MedicationReadDto>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<MedicationReadDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<MedicationReadDto>> GetByIdAsync(int id)
        {
            var medication = Medications.FirstOrDefault(m => m.MedId == id);

            if (medication == null)
                return Task.FromResult(new ServiceResponse<MedicationReadDto>($"Medication with Id {id} not found!"));

            return Task.FromResult(new ServiceResponse<MedicationReadDto>(medication));
        }
    }
}
