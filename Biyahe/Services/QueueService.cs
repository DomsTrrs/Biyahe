using Biyahe.DataAccess;
using Biyahe.Models;

namespace Biyahe.Services
{
    public class QueueService
    {
        private readonly QueueRepository _queueRepo = new QueueRepository();
        private readonly UserRepository _userRepo = new UserRepository();

        // Called when a user joins a queue — returns their queue ID and position
        public (int queueId, int position) JoinQueue(int userId, int routeId)
        {
            var user = _userRepo.GetUserById(userId);

            if (user == null)
                throw new Exception("User not found.");

            bool isPriority = user.SeniorOrPwd;

            return _queueRepo.JoinQueue(userId, routeId, isPriority);
        }

        // Called when a jeepney arrives — boards top N passengers
        public List<QueueEntry> BoardPassengers(int routeId, int driverId, int capacity)
        {
            var waiting = _queueRepo.GetQueueByRoute(routeId); // priority first
            var boarding = waiting.Take(capacity).ToList();
            var ids = boarding.Select(q => q.QueueID).ToList();

            _queueRepo.BoardPassengers(ids, driverId);
            return boarding;
        }
    }
}