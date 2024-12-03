using FitnessWorkoutMgmnt.Models;
using System.Threading.Tasks;

namespace FitnessWorkoutMgmnt.Repository
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessagesBetweenUsers(int senderId, int receiverId);
        Task<Message> SendMessage(Message message);
    }
}
