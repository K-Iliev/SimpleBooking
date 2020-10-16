using Domain.Booking;
using Domain.Common;
using FluentValidation;

namespace Application.Hotels.Commands
{
    public class AddRoomCommandValidator : AbstractValidator<AddRoomCommand>
    {
        public AddRoomCommandValidator()
        {
            this.RuleFor(c => c.RoomType)
                .Must(Enumeration.HasValue<RoomType>)
                .WithMessage("RoomType is not valid.");
        }
    }
}
