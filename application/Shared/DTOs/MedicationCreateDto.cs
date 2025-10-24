using System.ComponentModel.DataAnnotations;

namespace Application.Shared.DTOs
{
    public class MedicationCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        [Required]
        [Range(1, 31, ErrorMessage = "Day must be between 1 and 31.")]
        public int Day { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Month must be between 1 and 12.")]
        public int Month { get; set; }

        [Required]
        [Range(1900, 2100, ErrorMessage = "Year must be a valid year.")]
        public int Year { get; set; }
    }

}


