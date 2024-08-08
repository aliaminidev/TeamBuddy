using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.TeamMember.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TeamMember.Handlers.Commands
{
    public class DeleteTeamMemberRequestHandler : IRequestHandler<DeleteTeamMemberRequest>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        public DeleteTeamMemberRequestHandler(ITeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }

        public async Task Handle(DeleteTeamMemberRequest request, CancellationToken cancellationToken)
        {
            var teamMember = await _teamMemberRepository.Get(request.Id);
            await _teamMemberRepository.Delete(teamMember);
        }
    }
}
