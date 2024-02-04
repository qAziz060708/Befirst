namespace Befirst.DataAccess.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public string ClientName { get; set; }

        public string PaymentCategory { get; set; }

        public long MobileNumber { get; set; }
    }
}