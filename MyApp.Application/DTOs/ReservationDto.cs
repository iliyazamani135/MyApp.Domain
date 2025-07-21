// Application/DTOs/ReservationDto.cs
namespace MyApp.Domain.Entities
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public int ApartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserName { get; set; }
    }
}
