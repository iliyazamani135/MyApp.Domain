using MyApp.Application.DTOs;


namespace MyApp.Application.DTOs;


public class ApartmentDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal PricePerNight { get; set; }
    public int Capacity { get; set; }
}
