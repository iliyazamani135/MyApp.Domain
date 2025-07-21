using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyApp.Application.DTOs;

namespace MyApp.Application.Validators
{
    public class ApartmentDtoValidator : AbstractValidator<ApartmentDto>
    {
        public ApartmentDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("نام آپارتمان الزامی است.")
                .MaximumLength(100).WithMessage("نام نباید بیشتر از ۱۰۰ کاراکتر باشد.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("آدرس الزامی است.");

            RuleFor(x => x.PricePerNight)
                .GreaterThan(0).WithMessage("قیمت باید بیشتر از صفر باشد.");
        }
    }
}
// وقتی کاربر اطلاعاتی وارد میکنه ولیدیشن چک میکنه خالی نباشه فرمتشون درسته منطق برنامه ما مثل تاریخ رو رعایت میکنه یا نه 