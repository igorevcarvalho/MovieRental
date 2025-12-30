using FluentValidation;

namespace MovieRental.Rental.Validators
{
    public class RentalCustomerNameValidator : AbstractValidator<string>
    {
        public RentalCustomerNameValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage("Customer name is required."); 
            RuleFor(x => x).MinimumLength(2).WithMessage("Customer name must be at least 2 characters long."); 
            RuleFor(x => x).MaximumLength(100).WithMessage("Customer name must be no more than 100 characters long."); 
            RuleFor(x => x).Matches("^[a-zA-ZÀ-ÿ\\s]+$").WithMessage("Customer name contains invalid characters.");
        }
    }
}
