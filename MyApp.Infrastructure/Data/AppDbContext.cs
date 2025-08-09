using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // این دوتا خط یوزینگ رو اضافه کردم که به دیتابیس وصل شه و هم انتیتی هارو تشخیص بده 
using Myapp.Domain.Entities;
using MyApp.Domain.Entities; 

namespace MyApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext // ارث بری کرده از ای اف کور و خودش قراره پل ارتباطی با دیتا بیس باشه 
    {
        public DbSet<Apartment> Apartments { get; set; } // این خط یعنی یه جدول توی دیتابیس بسازه به اسم اپارتمان 

        public AppDbContext(DbContextOptions<AppDbContext> option) 
            : base(option) // با این خط کد ای اف کور کانفیگ دیتابیس رو به این کلاس میفرسته 
        {
        }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // این متد برای تنظیمات اضافی رو انتیتی هاعه 
        }
        public DbSet<User> Users { get; set; } // انتیتی کاربر 
        public DbSet<Comment> comments { get; set; }

    }
}
