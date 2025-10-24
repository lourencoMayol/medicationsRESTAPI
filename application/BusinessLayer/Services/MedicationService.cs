using Application.BusinessLayer.Models;
using Application.DataLayer.Interfaces;
using Application.BusinessLayer.Interfaces;
using Application.Shared;
using Application.Shared.DTOs;

namespace Application.BusinessLayer.Services
{
    public class MedicationService : IService<MedicationReadDto, MedicationCreateDto>
    {
        private readonly IRepository<Medication> Repo;

        public MedicationService(IRepository<Medication> repo)
        {
            Repo = repo;
        }

        public async Task<ServiceResponse<List<MedicationReadDto>>> GetAllAsync()
        {
            try
            {
                var medications = await Repo.GetAllAsync();

                if (medications == null || medications.Count == 0)
                    return new ServiceResponse<List<MedicationReadDto>>("There are no medication entries in the database");

                var dtos = MedicationMapper.AllToReadDto(medications.ToList());    

                return new ServiceResponse<List<MedicationReadDto>>(dtos);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<MedicationReadDto>>(new ServiceError(ex));
            }
        }

        public async Task<ServiceResponse<MedicationReadDto>> GetByIdAsync(int id)
        {
            try
            {
                var medication = await Repo.FindAsync(id);

                if (medication == null)
                    return new ServiceResponse<MedicationReadDto>("Medication with Id "+id+" not found!");

                return new ServiceResponse<MedicationReadDto>(MedicationMapper.ToReadDto(medication));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<MedicationReadDto>(new ServiceError(ex));
            }
        }

        public async Task<ServiceResponse<MedicationReadDto>> AddAsync(MedicationCreateDto dto)
        {
            try
            {
                var medication = MedicationMapper.ToDomain(dto);
                var created = await Repo.InsertAsync(medication);

                return new ServiceResponse<MedicationReadDto>(MedicationMapper.ToReadDto(created));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<MedicationReadDto>(new ServiceError(ex));
            }
        }

        public async Task<ServiceResponse<MedicationReadDto>> DeleteAsync(int id)
        {
            try
            {
                var deleted = await Repo.DeleteAsync(id);

                if (deleted == null)
                    return new ServiceResponse<MedicationReadDto>("Medication with Id "+id+" not found!");

                return new ServiceResponse<MedicationReadDto>(MedicationMapper.ToReadDto(deleted));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<MedicationReadDto>(new ServiceError(ex));
            }
        }
    }
}
