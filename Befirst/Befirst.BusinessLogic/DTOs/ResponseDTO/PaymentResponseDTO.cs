namespace Befirst.BusinessLogic.DTOs.ResponseDTO
{
    public class PaymentResponseDTO
    {
        public int PaymentId { get; set; }

        public string ClientName { get; set; }

        public string PaymentCategory { get; set; }

        public long MobileNumber { get; set; }
    }
}