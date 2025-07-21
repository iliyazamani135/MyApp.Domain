using Microsoft.EntityFrameworkCore;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence;

namespace MyApp.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _dbContext;

        public ReservationService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> MakeReservationAsync(Reservation reservation)
        {
            var exists = await _dbContext.Reservations
                .AnyAsync(r => r.ApartmentId == reservation.ApartmentId &&
                               ((reservation.StartDate >= r.StartDate && reservation.StartDate < r.EndDate) ||
                                (reservation.EndDate > r.StartDate && reservation.EndDate <= r.EndDate)));

            if (exists)
                return false;

            await _dbContext.Reservations.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<Reservation>> GetReservationsAsync() // توضیح پایین
        {
            return await _dbContext.Reservations.ToListAsync();
        }
        public async Task<Reservation?> GetReservationByIdAsync(Guid id)
        {
            return await _dbContext.Reservations.FindAsync(id);
        }
        public async Task<bool> DeleteReservationAsync(Guid id)
        {
            var reservation = await _dbContext.Reservations.FindAsync(id);

            if (reservation == null)
                return false;

            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        //این چیزی که زده شده برا همون مدیرس اگه خواست پاک کنه  فایند رو زدیم که بگرده اگه بود حذفش کنه و سیو کنه  
        public async Task<bool> UpdateReservationAsync(Guid id, ReservationRequestDto dto)
        {
            var reservation = await _dbContext.Reservations.FindAsync(id);

            if (reservation == null)
                return false;

            reservation.GuestName = dto.GuestName;
            reservation.StartDate = dto.StartDate;
            reservation.EndDate = dto.EndDate;
            reservation.ApartmentId = dto.ApartmentId;

            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
// چک میکنه تداخل نداشته باشه 
// چک میکنه تداخل نداشته باشه 

// توضیح بالا:
// ما با استفاده از دی بی کانتکس میریم سراغ جدول رزرویشن 
//تو لیست ای سینک یعنی همه رکورد هارو از دیتابیس میخونیم و به صورت لیست برمیگردونیم 
//چون با ای اف کور کار میکنیم اویت گذاشتیم تا عملیات ای سینک شه 
//در کل همه اینکارارو کردیم رزرو همزمان جلوگیری بشه 
//منطق اصلی ثبت قراداده اول برسی میکنیم ببینیم این بازه زمانی برای ان اپارتمان قبلا رزرو شده یا نه اگه تداخل داشت رزرو رو قبول نمیکنیم و فالس برمیگردونه در غیر این صورت رزرو را به دیتابیس اضافه میکنیم
