using Befirst.BusinessLogic.DTOs.RequestDTO;
using FluentValidation;

namespace Befirst.BusinessLogic.DTOs.RequestDTO
{
    public class PaymentRequestDTO
    {
        public string ClientName { get; set; }

        public string PaymentCategory { get; set; }

        public long MobileNumber { get; set; }
    }
}
public class PaymentRequestDTOValidator : AbstractValidator<PaymentRequestDTO>
{
    public PaymentRequestDTOValidator()
    {
        RuleFor(u => u.ClientName)
       .NotNull().WithMessage("Client Name must be entered.")
       .NotEmpty().WithMessage("Client Name cannot be empty.");

        RuleFor(u => u.PaymentCategory)
       .NotNull().WithMessage("PaymentCategory must be entered.")
       .NotEmpty().WithMessage("PaymentCategory cannot be empty.");

        RuleFor(u => u.MobileNumber)
       .NotNull().WithMessage("MobileNumber must be entered.")
       .NotEmpty().WithMessage("MobileNumber cannot be empty.");
    }
}