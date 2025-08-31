using MyApp.Domain.Entities;

namespace MyApp.Domain.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> GetByIdAsync(int id);
        Task AddAsync(Payment payment);
    }
}
