using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Subject { get; set; } 
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public Decimal PricePerNight { get; set; }
        public ICollection<Reservation> Reservations { get; set; } // ارتباط با رزروها
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public string Title { get; set; }
    } 
}
// هر اپارتمان میتونه چندتا زرزو داشته باشه ای کالکشن رزرو برای رابطه یک به چند استفاده میشه    
// این کد هایی که زدم انتیتی هستش ،انتیتی ها شی هویت دار مثل ادرس و قیمت انیتیتی هستن در واقع کلاس هایی هستن که اطلاعات اصلی سیستم رو نگه میدارن 