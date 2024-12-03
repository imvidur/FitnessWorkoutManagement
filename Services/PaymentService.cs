using FitnessWorkoutMgmnt.Models;
using FitnessWorkoutMgmnt.Repository;

namespace FitnessWorkoutMgmnt.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            return await _paymentRepository.CreatePaymentAsync(payment);
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _paymentRepository.GetPaymentByIdAsync(id);
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _paymentRepository.GetAllPaymentsAsync();
        }

        public async Task<Payment> UpdatePaymentAsync(int id, Payment payment)
        {
            return await _paymentRepository.UpdatePaymentAsync(id, payment);
        }

        public async Task DeletePaymentAsync(int id)
        {
            await _paymentRepository.DeletePaymentAsync(id);
        }
        public async Task<IEnumerable<Payment>> GetPaymentsForUser(int userId)
        {
            return await _paymentRepository.GetPaymentsForUser(userId);
        }

        public async Task<Payment> ProcessPayment(Payment payment)
        {
            return await _paymentRepository.AddPayment(payment);
        }
    }
}
