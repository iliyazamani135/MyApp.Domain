using MyApp.Domain.Entities;
using MyApp.Domain.ValueObjects;

namespace MyApp.Domain.Entities
{
    public class Payment
    {
        public int Id { get; private set; }
        public Reservation Reservation { get; private set; }
        public Money Amount { get; private set; }
        public DateTime PaidAt { get; private set; }

        public Payment(Reservation reservation, Money amount)
        {
            Reservation = reservation;
            Amount = amount;
            PaidAt = DateTime.UtcNow;
        }
    }
}
    

