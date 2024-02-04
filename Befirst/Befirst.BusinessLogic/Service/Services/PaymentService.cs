using AutoMapper;
using Befirst.BusinessLogic.DTOs.RequestDTO;
using Befirst.BusinessLogic.DTOs.ResponseDTO;
using Befirst.BusinessLogic.Service.IServices;
using Befirst.DataAccess.Models;
using Befirst.DataAccess.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Befirst.BusinessLogic.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<int> AddPaymentAsync(PaymentRequestDTO paymentRequestDTO)
        {
            try
            {
                return await _paymentRepository.AddPaymentAsync(_mapper.Map<Payment>(paymentRequestDTO));
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeletePaymentAsync(int id)
        {
            try
            {
                var PaymentResult = await _paymentRepository.GetPaymentByIdAsync(id);
                if (PaymentResult is not null)
                {
                    return await _paymentRepository.DeletePaymentAsync(PaymentResult);
                }
                else
                {
                    throw new Exception("Object cannot be deleted");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<PaymentResponseDTO>> GetAllPaymentsAsync(string? searchWord)
        {
            try
            {
                return _mapper.Map<List<PaymentResponseDTO>>(await _paymentRepository.GetAllPaymentsAsync(searchWord));
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PaymentResponseDTO> GetPaymentByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<PaymentResponseDTO>(await _paymentRepository.GetPaymentByIdAsync(id));
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdatePaymentAsync(PaymentRequestDTO paymentRequestDTO, int id)
        {
            try
            {
                var paymentResult = await _paymentRepository.GetPaymentByIdAsync(id);
                if (paymentResult is not null)
                {
                    paymentResult = _mapper.Map<Payment>(paymentRequestDTO);
                    paymentResult.PaymentId = id;
                    return await _paymentRepository.UpdatePaymentAsync(paymentResult);
                }
                else
                {
                    throw new Exception("Object cannot be updated.");
                }
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed.");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was updating changes.");
            }
        }
    }
}