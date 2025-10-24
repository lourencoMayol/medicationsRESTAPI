namespace Application.BusinessLayer.Models
{

    public class Medication
    {

        public string Name { get; private set; }

        public int Quantity { get; private set; }

        public DateTime CreationDate { get; private set; }

        public int MedId { get; private set; }

        public Medication(string name, int quantity, int day, int month, int year)
        {
            

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "The medication's name cannot be null or empty!");

            if (quantity <= 0)
                throw new ArgumentException("The medication's quantity must be greater than 0!", nameof(quantity));

            if (day <= 0 || month <= 0 || year <= 0)
                throw new ArgumentException("Invalid date components! Day, month, and year must be positive integers.");

            try
            {
                this.Name = name;
                this.Quantity = quantity;
                this.CreationDate = new DateTime(year, month, day);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentException("The provided date is not valid!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Medication() { }
    }
}
