using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Team.Validators;
using TeamBuddy.Application.DTOs.TeamMember.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.TeamMember.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TeamMember.Handlers.Commands
{
    public class CreateTeamMemberRequestHandler : IRequestHandler<CreateTeamMemberRequest, int>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;

        public CreateTeamMemberRequestHandler(ITeamMemberRepository teamMemberRepository, IMapper mapper, ITeamRepository teamRepository)
        {
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        public async Task<int> Handle(CreateTeamMemberRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateTeamMemberDtoValidator(_teamRepository);
            var validationResult = await validator.ValidateAsync(request.CreateTeamMemberDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var teamMember = _mapper.Map<Domain.TeamMember>(request.CreateTeamMemberDto);
            teamMember = await _teamMemberRepository.Add(teamMember);
            return teamMember.Id;
        }
    }
}
