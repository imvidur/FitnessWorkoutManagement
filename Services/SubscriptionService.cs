using FitnessWorkoutMgmnt.Models;
using FitnessWorkoutMgmnt.Repository;

namespace FitnessWorkoutMgmnt.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<Subscription> CreateSubscriptionAsync(Subscription subscription)
        {
            return await _subscriptionRepository.CreateSubscriptionAsync(subscription);
        }

        public async Task<Subscription> GetSubscriptionByIdAsync(int id)
        {
            return await _subscriptionRepository.GetSubscriptionByIdAsync(id);
        }

        public async Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync()
        {
            return await _subscriptionRepository.GetAllSubscriptionsAsync();
        }

        public async Task<Subscription> UpdateSubscriptionAsync(int id, Subscription subscription)
        {
            return await _subscriptionRepository.UpdateSubscriptionAsync(id, subscription);
        }

        public async Task DeleteSubscriptionAsync(int id)
        {
            await _subscriptionRepository.DeleteSubscriptionAsync(id);
        }
    }
}
