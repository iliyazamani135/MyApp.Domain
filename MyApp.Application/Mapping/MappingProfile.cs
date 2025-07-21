using AutoMapper;
using MyApp.Domain.Entities;
using MyApp.Application.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyApp.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApartmentDto, Apartment>().ReverseMap(); //مشخص میکنه که یه انتیتی چطور به دی تی او تبدیل بشه 
        CreateMap<ReservationRequestDto, Reservation>().ReverseMap(); // رزرو مپ یعنی اینکه تبدیل دو طرفه انجام بشه
    }
}
// این یه کلاسی برای تعریف قوانین مپ کردن 