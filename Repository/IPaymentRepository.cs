using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Repository
{
    public interface IPaymentRepository
    {
        Task<Payment> CreatePaymentAsync(Payment payment);
        Task<Payment> GetPaymentByIdAsync(int id);
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<Payment> UpdatePaymentAsync(int id, Payment payment);
        Task DeletePaymentAsync(int id);
       
            Task<IEnumerable<Payment>> GetPaymentsForUser(int userId);
            Task<Payment> AddPayment(Payment payment);

    }
}
