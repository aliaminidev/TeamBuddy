using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Match;
using TeamBuddy.Application.Features.Match.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Match.Handlers.Queries
{
    public class GetMatchRequestHandler : IRequestHandler<GetMatchRequest, MatchDto>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public GetMatchRequestHandler(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<MatchDto> Handle(GetMatchRequest request, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.Get(request.Id);
            return _mapper.Map<MatchDto>(match);
        }
    }
}
