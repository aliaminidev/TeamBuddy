using System.Threading.Tasks;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.Persistence.Contracts
{
    public interface ITeamMemberRepository : IGenericRepository<TeamMember, int>
    {
        Task<bool> IsPlayerExist(int id);
    }
}
