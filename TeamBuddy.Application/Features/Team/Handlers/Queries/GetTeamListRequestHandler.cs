using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Team;
using TeamBuddy.Application.Features.Team.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Team.Handlers.Queries
{
    public class GetTeamListRequestHandler : IRequestHandler<GetTeamListRequest, List<TeamDto>>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public GetTeamListRequestHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<List<TeamDto>> Handle(GetTeamListRequest request, CancellationToken cancellationToken)
        {
            var teamList = await _teamRepository.GetAll();
            return _mapper.Map<List<TeamDto>>(teamList);
        }
    }
}
