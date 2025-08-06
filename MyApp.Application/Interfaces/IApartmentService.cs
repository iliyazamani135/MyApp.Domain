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
        Task AddApartmentAsync(ApartmentDto apartmentDto);
        Task<bool> UpdateApartmentAsync(Guid id, ApartmentDto apartmentDto);
        Task<bool> DeleteApartmentAsync(Guid id);
        Task<bool> UpdateApartmentAsync(Guid id, UpdateApartmentDto dto);
    }
}
