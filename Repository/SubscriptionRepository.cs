using FitnessWorkoutMgmnt.Data;
using FitnessWorkoutMgmnt.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutMgmnt.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly FitnessDbContext _context;

        public SubscriptionRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Subscription> CreateSubscriptionAsync(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }

        public async Task<Subscription> GetSubscriptionByIdAsync(int id)
        {
            return await _context.Subscriptions.FirstOrDefaultAsync(s => s.SubscriptionId == id);
        }

        public async Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<Subscription> UpdateSubscriptionAsync(int id, Subscription subscription)
        {
            var existingSubscription = await GetSubscriptionByIdAsync(id);
            if (existingSubscription == null)
                return null;

            existingSubscription.SubscriptionType = subscription.SubscriptionType;
            existingSubscription.StartDate = subscription.StartDate;
            existingSubscription.EndDate = subscription.EndDate;
            // Update other fields

            await _context.SaveChangesAsync();
            return existingSubscription;
        }

        public async Task DeleteSubscriptionAsync(int id)
        {
            var subscription = await GetSubscriptionByIdAsync(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
            }
        }
    }
}
