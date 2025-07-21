using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid ApartmentId { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Apartment Apartment { get; set; } //نویگیشن پراپرتی برای ارتباط با ای اف کور 
        public string GuestName { get; set; }

    }
}
// این کد زده شده که سیستم مدیریت بشه و کلاس مدل اصلی رزرو اپارتمان است 