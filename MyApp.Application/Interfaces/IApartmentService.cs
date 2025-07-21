using MyApp.Application.DTOs;
using MyApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IApartmentService
    {
        Task<List<Apartment>> GetAllApartmentsAsync();
        Task AddApartmentAsync(Apartment apartment);
        Task<ApartmentDto> GetApartmentByIdAsync(Guid id);

    }
}
