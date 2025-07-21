using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces;
using MyApp.Domain;
using MyApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace MyAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> MakeReservation([FromBody] ReservationRequestDto request)
        {
            var reservation = new Reservation
            {
                ApartmentId = request.ApartmentId,
                GuestName = request.GuestName,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            var result = await _reservationService.MakeReservationAsync(reservation);

            if (!result)
                return BadRequest("رزرو انجام نشد. شاید آپارتمان در این تاریخ قبلاً رزرو شده.");

            return Ok("رزرو با موفقیت انجام شد.");
        }
        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await _reservationService.GetReservationsAsync();
            return Ok(reservations);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(Guid id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);

            if (reservation == null)
                return NotFound(); // 404 اگر پیدا نشد

            return Ok(reservation); // 200 با داده‌ی رزرو
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            var result = await _reservationService.DeleteReservationAsync(id);

            if (!result)
                return NotFound(); // رزرو پیدا نشد

            return NoContent(); // 204: موفق ولی داده‌ای نیست که برگردونیم
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(Guid id, [FromBody] ReservationRequestDto dto)
        {
            var result = await _reservationService.UpdateReservationAsync(id, dto);

            if (!result)
                return NotFound();

            return NoContent(); // اگر با موفقیت آپدیت شد
        }


    }
}
//برای دریافت رزرو جدید این کدارو نوشتیم نحوه کارش به صورت زیر 
//اطلاعات که کاربر تو دی تی او زده رو میگیره ذخیره میکنه اگه تداخل نداشت رزرو میکنه