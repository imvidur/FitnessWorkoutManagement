using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetMessagesBetweenUsers(int senderId, int receiverId);
        Task<Message> SendMessage(Message message);
    }
}
