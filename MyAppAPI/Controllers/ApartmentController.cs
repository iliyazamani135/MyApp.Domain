using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using AutoMapper;


namespace MyAppAPI.Controllers
{
    [ApiController] // این خط میفهمونه کارهایمثل ولیدیش خودکارانجام بشه 
    [Route("api/[controller]")] 
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService; //این خط کد برای نگه داری وابستگ ها است و از طریق کانستراکتور ان ر مقار میدیم

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var apartments = await _apartmentService.GetAllApartmentsAsync();
            return Ok(apartments);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Apartment apartment)
        {
            await _apartmentService.AddApartmentAsync(apartment);
            return Ok("Added");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var apartment = await _apartmentService.GetApartmentByIdAsync(id);

            if (apartment == null)
                return NotFound();

            return Ok(apartment);
        }
       
    }
}

// کل این صفحه یه واسطه بین کابر و منطق برنامس درخواست میگیره از کاربر با استفاده از سرویس داده هارو میخونه یا ذخیره میکنه و جواب میده 


