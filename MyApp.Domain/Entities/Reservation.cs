using MyApp.Domain.Enums;
using MyApp.Domain.ValueObjects;


namespace MyApp.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; private set; }
        public User User { get; private set; }
        public Apartment Apartment { get; private set; }
        public DateRange Period { get; private set; }
        public ReservationStatus Status { get; private set; }

        public Reservation(User user, Apartment apartment, DateRange period)
        {
            User = user;
            Apartment = apartment;
            Period = period;
            Status = ReservationStatus.Pending;
        }

        public void Confirm()
        {
            Status = ReservationStatus.Confirmed;
        }

        public void Cancel()
        {
            Status = ReservationStatus.Cancelled;
        }
    }
}

// این کد زده شده که سیستم مدیریت بشه و کلاس مدل اصلی رزرو اپارتمان است 