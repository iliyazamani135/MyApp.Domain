using MyApp.Domain.Entities;
using MyApp.Domain.ValueObjects;

namespace MyApp.Domain.DomainServices

{
    public class ReservationService
    {
        public bool CanReserve(Apartment apartment, DateRange period, List<Reservation> existingReservations)
        {
            // بررسی تداخل رزرو
            foreach (var r in existingReservations)
            {
                if (r.Period.Start < period.End && period.Start < r.Period.End)
                    return false;
            }
            return true;
        }
    }
}

