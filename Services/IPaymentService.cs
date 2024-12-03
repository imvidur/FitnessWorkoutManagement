using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Services
{
    public interface IPaymentService
    {
        Task<Payment> CreatePaymentAsync(Payment payment);
        Task<Payment> GetPaymentByIdAsync(int id);
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<Payment> UpdatePaymentAsync(int id, Payment payment);
        Task DeletePaymentAsync(int id);

        Task<IEnumerable<Payment>> GetPaymentsForUser(int userId);
        Task<Payment> ProcessPayment(Payment payment);
    }
}
