using Befirst.BusinessLogic.DTOs.RequestDTO;
using Befirst.DataAccess.Models;
using FluentValidation;

namespace Befirst.BusinessLogic.DTOs.RequestDTO
{
    public class ClientRequestDTO
    {
        public string ClientFirstName { get; set; }

        public string ClientLastName { get; set; }

        public string Age { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }
    }
}
public class ClientRequestDTOValidator : AbstractValidator<ClientRequestDTO>
{
    public ClientRequestDTOValidator()
    {
        RuleFor(u => u.ClientFirstName)
       .NotNull().WithMessage("Client First Name must be entered.")
       .NotEmpty().WithMessage("Client First Name cannot be empty.");

        RuleFor(u => u.ClientLastName)
           .NotNull().WithMessage("Client Last Name must be entered.")
           .NotEmpty().WithMessage("Client Last Name cannot be empty.");

        RuleFor(u => u.Age)
            .NotNull().WithMessage("Age must be entered.")
            .NotEmpty().WithMessage("Age cannot be empty.");

        RuleFor(u => u.Category)
            .NotNull().WithMessage("Category must be entered.")
            .NotEmpty().WithMessage("Category cannot be empty.");

        RuleFor(u => u.Description)
           .NotNull().WithMessage("Description must be entered.")
           .NotEmpty().WithMessage("Description cannot be empty.");

        RuleFor(u => u.City)
           .NotNull().WithMessage("City must be entered.")
           .NotEmpty().WithMessage("City cannot be empty.");

        RuleFor(u => u.Gender)
           .NotNull().WithMessage("Gender must be entered.")
           .IsInEnum().WithMessage("Entered incorrectly.");

        RuleFor(u => u.PhoneNumber)
           .NotNull().WithMessage("Phone number must be entered.")
           .NotEmpty().WithMessage("Phone number cannot be empty.");
    }
}