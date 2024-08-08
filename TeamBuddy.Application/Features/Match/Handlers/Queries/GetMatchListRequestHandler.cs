using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Match;
using TeamBuddy.Application.Features.Match.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Match.Handlers.Queries
{
    public class GetMatchListRequestHandler : IRequestHandler<GetMatchListRequest, List<MatchDto>>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public GetMatchListRequestHandler(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<List<MatchDto>> Handle(GetMatchListRequest request, CancellationToken cancellationToken)
        {
            var matchList = await _matchRepository.GetAll();
            return _mapper.Map<List<MatchDto>>(matchList);
        }
    }
}
