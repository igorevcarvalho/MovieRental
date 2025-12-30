using FluentValidation;
using MovieRental.Rental.Requests;

namespace MovieRental.Rental.Validators
{
    public class RentalSaveRequestValidator : AbstractValidator<RentalSaveRequest>
    {
        public RentalSaveRequestValidator()
        {
            RuleFor(x => x.MovieId).GreaterThan(0)
                .WithMessage("Movie must be selected");

            RuleFor(x => x.DaysRented).GreaterThan(0)
                .WithMessage("Days rented must be greater than zero");

            RuleFor(x => x.CustomerId).GreaterThan(0)
                .WithMessage("Customer must be selected");

            RuleFor(x => x.PaymentMethodId).GreaterThan(0)
                .WithMessage("Payment method must be selected");

        }
    }
}
