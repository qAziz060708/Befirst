using Befirst.BusinessLogic.DTOs.RequestDTO;
using Befirst.BusinessLogic.DTOs.ResponseDTO;

namespace Befirst.BusinessLogic.Service.IServices
{
    public interface IPaymentService
    {
        Task<int> AddPaymentAsync(PaymentRequestDTO paymentRequestDTO);

        Task<int> UpdatePaymentAsync(PaymentRequestDTO paymentRequestDTO, int id);

        Task<int> DeletePaymentAsync(int id);

        Task<PaymentResponseDTO> GetPaymentByIdAsync(int id);

        Task<List<PaymentResponseDTO>> GetAllPaymentsAsync(string? searchWord);
    }
}