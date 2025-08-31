using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence;

namespace MyApp.Infrastructure.Services
{
    public class ApartmentService : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ApartmentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddApartmentAsync(Apartment apartment)
        {
            await _context.Apartments.AddAsync(apartment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ApartmentDto>> GetAllApartmentsAsync()
        {
            var apartments = await _context.Apartments.ToListAsync();
            return _mapper.Map<List<ApartmentDto>>(apartments);
        }

        public async Task<ApartmentDto> GetApartmentByIdAsync(Guid id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
                return null;

            return _mapper.Map<ApartmentDto>(apartment);
        }

        public async Task<bool> UpdateApartmentAsync(Guid id, UpdateApartmentDto dto)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
                return false;

            apartment.Subject = dto.Subject;
            apartment.Address = dto.Address;
            apartment.Price = dto.Price;
            apartment.Name = dto.Name;
            apartment.PricePerNight = dto.PricePerNight;
            apartment.Title = dto.Title;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteApartmentAsync(Guid id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
                return false;

            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
