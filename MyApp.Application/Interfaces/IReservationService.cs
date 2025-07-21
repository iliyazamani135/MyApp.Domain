using MyApp.Application.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.Application.Interfaces
{
    public interface IReservationService
    {
        Task<bool> MakeReservationAsync(Reservation reservation);// بول برا برگشتی نوشته میشه


        Task<List<Reservation>> GetReservationsAsync(); // این متد به اینترفیس اضافه شد تا سرویس ما بتونه لیست رزروهارو بده 
        Task<Reservation?> GetReservationByIdAsync(Guid id); // این متد یه ایدی میگیره و یه رزرویشن برمیگردونه یا نال برمیگردونه
        Task<bool> DeleteReservationAsync(Guid id);   // این متد وقتی رییس کل بخواد دیلیت کنه یهرزرو اشتباهی رو 
        Task<bool> UpdateReservationAsync(Guid id, ReservationRequestDto dto);// برای اپدیت 

    }
}

//اینترفیس فقط امضای متد رو میده نه بدنه اونو 
//ایجاد قراردادی بین لایه ها که پیاده سازی مستقل و تست پذیر باشه