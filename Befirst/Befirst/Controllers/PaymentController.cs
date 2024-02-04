using AutoMapper;
using FluentValidation;
using Befirst.BusinessLogic.DTOs.RequestDTO;
using Befirst.BusinessLogic.DTOs.ResponseDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Befirst.BusinessLogic.Service.IServices;
using Befirst.BusinessLogic.Service.Services;

namespace Befirst.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IValidator<PaymentRequestDTO> _validator;

        public PaymentController(IPaymentService paymentService, IValidator<PaymentRequestDTO> validator)
        {
            _paymentService = paymentService;
            _validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddPaymentAsync(PaymentRequestDTO paymentRequestDTO)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(paymentRequestDTO);
                if (validationResult.IsValid)
                {
                    return await _paymentService.AddPaymentAsync(paymentRequestDTO);
                }
                else
                {
                    throw new Exception("You entered the values incorrectly or incompletely, please try to enter them all correctly and completely again.");
                }
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpGet("Id")]
        public async Task<ActionResult<PaymentResponseDTO>> GetPaymentByIdAsync(int id)
        {
            try
            {
                return await _paymentService.GetPaymentByIdAsync(id);
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<PaymentResponseDTO>>> GetAllPaymentsAsync(string? searchWord)
        {
            try
            {
                return await _paymentService.GetAllPaymentsAsync(searchWord);
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("Id")]
        public async Task<ActionResult<int>> UpdatePaymentAsync(PaymentRequestDTO paymentRequestDTO, int id)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(paymentRequestDTO);
                if (validationResult.IsValid)
                {
                    return await _paymentService.UpdatePaymentAsync(paymentRequestDTO, id);
                }
                else
                {
                    throw new Exception("Payment for update is not available.");
                }
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpDelete("Id")]
        public async Task<ActionResult<int>> DeletePaymentAsync(int id)
        {
            try
            {
                return await _paymentService.DeletePaymentAsync(id);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}