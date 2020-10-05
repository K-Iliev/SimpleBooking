using FluentValidation;

namespace Application.Booking.Commands
{
    public class AddHotelCommandValidator : AbstractValidator<AddHotelCommand>
    {
        public AddHotelCommandValidator()
        {
            this.RuleFor(x => x.Location)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(150);

            this.RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(150);
        }
    }
}
