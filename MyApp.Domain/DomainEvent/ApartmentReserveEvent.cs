namespace MyApp.Domain.DomainEvent
{
    public class ApartmentReservedEvent
    {
        public int ReservationId { get; }
        public DateTime ReservedAt { get; }

        public ApartmentReservedEvent(int reservationId)
        {
            ReservationId = reservationId;
            ReservedAt = DateTime.UtcNow;
        }
    }
}
//just notification