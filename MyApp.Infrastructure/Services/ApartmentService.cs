using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.DTOs;
using AutoMapper;
namespace MyApp.Infrastructure.Services
{
    public class ApartmentService
    {
        public async Task<ApartmentDto> GetApartmentByIdAsync(Guid id)
        {
            var apartment = await _context.Apartments.FindAsync(id);

            if (apartment == null)
                return null;

            return _mapper.Map<ApartmentDto>(apartment);
        }

    }
}
