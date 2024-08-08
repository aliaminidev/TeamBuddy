using System.Threading.Tasks;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.Persistence.Contracts
{
    public interface ITrainingSessionRepository : IGenericRepository<TrainingSession, int>
    {
        Task<int> GetDuration(int id);
    }
}
