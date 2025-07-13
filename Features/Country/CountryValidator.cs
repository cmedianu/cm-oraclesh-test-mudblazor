using FluentValidation;

namespace Features.Country
{
    public class CountryValidator : AbstractValidator<CountryDto>
    {
        public CountryValidator()
        {
            RuleFor(x => x.CountryName).NotEmpty().WithMessage("Country name is required");
            RuleFor(x => x.CountryIsoCode).NotEmpty().WithMessage("ISO code is required");
        }
    }
} 