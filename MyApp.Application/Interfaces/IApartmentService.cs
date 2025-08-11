//using MyApp.Application.DTOs;
//using MyApp.Domain.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace MyApp.Application.Interfaces
//{
//    public interface IApartmentService
//    {
//        Task<List<Apartment>> GetAllApartmentsAsync();
//        Task AddApartmentAsync(Apartment apartment);
//        Task<ApartmentDto> GetApartmentByIdAsync();
//        Task AddApartmentAsync(ApartmentDto apartmentDto);
//        Task<bool> UpdateApartmentAsync(Guid id, ApartmentDto apartmentDto);
//        Task<bool> DeleteApartmentAsync(Guid id);
//        Task<bool> UpdateApartmentAsync(Guid id, UpdateApartmentDto dto);
//    }
//}
using MyApp.Application.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.Application.Interfaces
{
    public interface IApartmentService
    {
        // ایجاد آپارتمان با Entity اصلی
        Task AddApartmentAsync(Apartment apartment);

        // گرفتن همه آپارتمان‌ها به صورت DTO
        Task<List<ApartmentDto>> GetAllApartmentsAsync();

        // گرفتن یک آپارتمان بر اساس Id به صورت DTO
        Task<ApartmentDto> GetApartmentByIdAsync(Guid id);

        // بروزرسانی با DTO مخصوص آپدیت
        Task<bool> UpdateApartmentAsync(Guid id, UpdateApartmentDto dto);

        // حذف آپارتمان
        Task<bool> DeleteApartmentAsync(Guid id);
    }
}
