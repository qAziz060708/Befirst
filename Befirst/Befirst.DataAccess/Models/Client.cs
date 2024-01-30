namespace Befirst.DataAccess.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        public string ClientFirstName { get; set; }

        public string ClientLastName { get; set; }

        public string Age { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }
    }

    public enum Gender
    {
        Male,
        Famale
    }
}