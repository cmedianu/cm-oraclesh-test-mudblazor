using FluentValidation;

namespace Features.Client
{
    public class ClientValidator : AbstractValidator<ClientDto>
    {
        public ClientValidator()
        {
            RuleFor(x => x.CustFirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.CustLastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.CustGender).NotEmpty().WithMessage("Gender is required");
            RuleFor(x => x.CustYearOfBirth)
                .NotNull().WithMessage("Year of birth is required")
                .InclusiveBetween(1900, (decimal)DateTime.Now.Year).WithMessage($"Year of birth must be between 1900 and {DateTime.Now.Year}");
            RuleFor(x => x.CustMaritalStatus).NotEmpty().WithMessage("Marital status is required");
            RuleFor(x => x.CustCity).NotEmpty().WithMessage("City is required");
            RuleFor(x => x.CustStateProvince).NotEmpty().WithMessage("State/Province is required");
            RuleFor(x => x.CountryId).NotNull().WithMessage("Country is required");
            RuleFor(x => x.CustEmail)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.CustMainPhoneNumber).NotEmpty().WithMessage("Main phone number is required");
            RuleFor(x => x.CustStreetAddress).NotEmpty().WithMessage("Street address is required");
        }
    }
} 