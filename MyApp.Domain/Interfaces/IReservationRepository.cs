using MyApp.Domain.Entities;

namespace MyApp.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> GetByIdAsync(int id);
        Task AddAsync(Reservation reservation);
        Task<List<Reservation>> GetReservationsForApartmentAsync(int apartmentId);
        // بول برا برگشتی نوشته میشه


        // این متد به اینترفیس اضافه شد تا سرویس ما بتونه لیست رزروهارو بده 
        // این متد یه ایدی میگیره و یه رزرویشن برمیگردونه یا نال برمیگردونه
        // این متد وقتی رییس کل بخواد دیلیت کنه یهرزرو اشتباهی رو 
        // برای اپدیت 

    }
}

//اینترفیس فقط امضای متد رو میده نه بدنه اونو 
//ایجاد قراردادی بین لایه ها که پیاده سازی مستقل و تست پذیر باشه