using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositories
{
     public class ApartmentRepository : IApartmentRepository
    {
        private readonly AppDbContext _context; // پر میشه یه فیلد خصوصوی که از طریق کانستراکتور 

        public ApartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Apartment?> GetByIdAsync(Guid id) // با استفاده از ای اف کور رکورد اپارتمان براساس ایدی میگیرد 
        {
            return await _context.Apartments.FindAsync(id);  // متد فایند ای سینک متدی که سریع برمیگردونه حالا چه خالی چه پر 
        }

        public async Task AddAsync(Apartment apartment)
        {
            await _context.Apartments.AddAsync(apartment); // اپارتمان جدید را به جدول دیتابیس اضافه میکند 
        }

        public Task<List<Apartment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
 // اویت برای این نوشته میشه که ما مثلا میگیم برو یه کاری رو انجام بده من اینجا وایسادم تا بیای که برنامه متوقف نشه 