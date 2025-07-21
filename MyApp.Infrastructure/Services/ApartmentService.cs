using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.DTOs;
using MyApp.Domain.Entities;
using AutoMapper;
using MyApp.Infrastructure.Persistence;

namespace MyApp.Infrastructure.Services
{
    public class ApartmentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ApartmentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApartmentDto> GetApartmentByIdAsync(Guid id)
        {
            var apartment = await _context.Apartments.FindAsync(id);

            if (apartment == null)
                return null;

            return _mapper.Map<ApartmentDto>(apartment);
        }
    }
}
