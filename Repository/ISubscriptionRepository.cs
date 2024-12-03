using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Repository
{
    public interface ISubscriptionRepository
    {
        Task<Subscription> CreateSubscriptionAsync(Subscription subscription);
        Task<Subscription> GetSubscriptionByIdAsync(int id);
        Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync();
        Task<Subscription> UpdateSubscriptionAsync(int id, Subscription subscription);
        Task DeleteSubscriptionAsync(int id);
    }
}
