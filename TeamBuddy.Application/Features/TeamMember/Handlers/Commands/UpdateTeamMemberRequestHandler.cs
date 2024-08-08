using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.TeamMember;
using TeamBuddy.Application.Features.TeamMember.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TeamMember.Handlers.Commands
{
    public class UpdateTeamMemberRequestHandler : IRequestHandler<UpdateTeamMemberRequest>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IMapper _mapper;

        public UpdateTeamMemberRequestHandler(ITeamMemberRepository teamMemberRepository, IMapper mapper)
        {
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTeamMemberRequest request, CancellationToken cancellationToken)
        {
            var teamMember = await _teamMemberRepository.Get(request.UpdateTeamMemberDto.Id);
            _mapper.Map(request.UpdateTeamMemberDto, teamMember);
            await _teamMemberRepository.Update(teamMember);
        }
    }
}
