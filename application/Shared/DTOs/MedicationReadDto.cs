namespace Application.Shared.DTOs
{
    public class MedicationReadDto
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
        public int MedId { get; set; }
    }
}
