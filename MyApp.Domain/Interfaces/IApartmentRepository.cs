using MyApp.Domain.Entities;

namespace MyApp.Domain.Interfaces
{
    public interface IApartmentRepository
    {

        Task<Apartment> GetByIdAsync(int id);
        Task AddAsync(Apartment apartment);
        Task<List<Apartment>> GetAllAsync();
    }   
}
         // این کد الان متد هستش که میگه با ایدی یه اپارتمان باید پیدا شه و علامت سوال هم برا اینه که بتونه این اپشن خالی باشه یعنی پیدا نشه 
         // این متدی که من نوشتم برای اینه که بتونه یه اپارتمان جدید اضافه کنه 
    

// متد هارو ای سینک زدیم که بعدا بتونه ای اف کور برگردونه 
// این کد هایی که من نوشتم برای اینترفیس هست که در لایه ی اپلیکیشن نوشته میشه و اینکه اینترفیس یه قرارداد میگه چکاری باید انجام شه انجام نمیده در واقع میگه هرکسی اینو پیاده میکنه باید این متد هارو داشته باشه 