using Application.BusinessLayer.Models;
using Application.Shared.DTOs;

namespace Application.Shared
{
    public static class MedicationMapper
    {
        public static Medication ToDomain(MedicationCreateDto dto)
        {
            return new Medication(
                dto.Name,
                dto.Quantity,
                dto.Day,
                dto.Month,
                dto.Year
            );
        }

        public static MedicationReadDto ToReadDto(Medication medication)
        {
            return new MedicationReadDto
            {
                Name = medication.Name,
                Quantity = medication.Quantity,
                CreationDate = medication.CreationDate,
                MedId = medication.MedId
            };
        }

        public static List<MedicationReadDto> AllToReadDto(List<Medication> medications)
        {
            List<MedicationReadDto> dtos = new List<MedicationReadDto>();
            foreach (Medication medication in medications) {

                MedicationReadDto dto = new MedicationReadDto
                {
                    Name = medication.Name,
                    Quantity = medication.Quantity,
                    CreationDate = medication.CreationDate,
                    MedId = medication.MedId
                };
                dtos.Add(dto);

            }

            return dtos;
            
        }
    }
}
