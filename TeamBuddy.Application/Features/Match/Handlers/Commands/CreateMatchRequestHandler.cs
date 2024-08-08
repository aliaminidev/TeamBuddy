using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.Match.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Match.Handlers.Commands
{
    public class CreateMatchRequestHandler : IRequestHandler<CreateMatchRequest, int>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public CreateMatchRequestHandler(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateMatchRequest request, CancellationToken cancellationToken)
        {
            var match = _mapper.Map<Domain.Match>(request.CreateMatchDto);
            match = await _matchRepository.Add(match);
            return match.Id;
        }
    }
}
