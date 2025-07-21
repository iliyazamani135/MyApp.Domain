using AutoMapper;
using MyApp.Application.DTOs;


namespace MyApp.Application.DTOs;


public class ApartmentDto
{
    private readonly IMapper _mapper;

    public string Title { get; set; }
    public string Description { get; set; }
    public decimal PricePerNight { get; set; }
    public int Capacity { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}
