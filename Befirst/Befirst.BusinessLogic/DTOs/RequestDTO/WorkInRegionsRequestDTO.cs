using Befirst.BusinessLogic.DTOs.RequestDTO;
using FluentValidation;

namespace Befirst.BusinessLogic.DTOs.RequestDTO
{
    public class WorkInRegionsRequestDTO
    {
        public string Region { get; set; }

        public string School { get; set; }

        public string Kindergarten { get; set; }

        public int Amount { get; set; }
    }
}
public class WorkInRegionsRequestDTOValidator : AbstractValidator<WorkInRegionsRequestDTO>
{
     public WorkInRegionsRequestDTOValidator()
     {
        RuleFor(u => u.Region)
            .NotNull().WithMessage("Region must be entered.")
            .NotEmpty().WithMessage("Region cannot be empty.");

        RuleFor(u => u.School)
            .NotNull().WithMessage("School must be entered.")
            .NotEmpty().WithMessage("School cannot be empty.");

        RuleFor(u => u.Kindergarten)
            .NotNull().WithMessage("Kindergarten must be entered.")
            .NotEmpty().WithMessage("Kindergarten cannot be empty.");

        RuleFor(u => u.Amount)
            .NotNull().WithMessage("Amount must be entered.")
            .NotEmpty().WithMessage("Amount cannot be empty.");
     }
}