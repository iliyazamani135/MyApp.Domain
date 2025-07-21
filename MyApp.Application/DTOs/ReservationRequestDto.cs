namespace MyApp.Application.DTOs
{
    public class ReservationRequestDto
    {
        public Guid ApartmentId { get; set; }
        public string GuestName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
//یه کد ساده برای گرفتن اطلاعات از کاربر
// ما مستقیم انتیتی رو نمیگیریم با دی تی او میگیریم چون امن تر و تمیز تره 