using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.DTOs;
using MyApp.Domain.Entities;
using AutoMapper;
using MyApp.Infrastructure.Persistence;
using MyApp.Application.Interfaces;

namespace MyApp.Infrastructure.Services
{
    public class ApartmentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _repository;
        public ApartmentService(AppDbContext context, IMapper mapper, IApartmentRepository repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }

        public ApartmentService(IApartmentRepository @object, IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ApartmentDto> GetApartmentByIdAsync(Guid id)
        {
            var apartment = await _context.Apartments.FindAsync(id);

            if (apartment == null)
                return null;

            return _mapper.Map<ApartmentDto>(apartment);
        }

        public async Task<List<ApartmentDto>> GetAllApartmentsAsync()
        {
            var apartments = await _context.Apartments.ToListAsync();
            return _mapper.Map<List<ApartmentDto>>(apartments);
        }
    }
}
