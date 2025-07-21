using FluentValidation;
using MyApp.Application.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.Application.Validators
{
    public class ReservationDtoValidator : AbstractValidator<ReservationDto>
    {
        public ReservationDtoValidator()
        {
            RuleFor(x => x.ApartmentId)
                .GreaterThan(0).WithMessage("شناسه آپارتمان باید بزرگ‌تر از صفر باشد.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("نام کاربر نباید خالی باشد.")
                .MaximumLength(100).WithMessage("نام کاربر نباید بیش از ۱۰۰ کاراکتر باشد.");

            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate).WithMessage("تاریخ شروع باید قبل از تاریخ پایان باشد.");

            RuleFor(x => x.EndDate)
                .GreaterThan(DateTime.Now).WithMessage("تاریخ پایان باید در آینده باشد.");
        }
    }
}
