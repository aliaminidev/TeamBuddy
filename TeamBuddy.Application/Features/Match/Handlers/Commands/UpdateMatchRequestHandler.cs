using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Match;
using TeamBuddy.Application.Features.Match.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Match.Handlers.Commands
{
    public class UpdateMatchRequestHandler : IRequestHandler<UpdateMatchRequest>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public UpdateMatchRequestHandler(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateMatchRequest request, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.Get(request.UpdateMatchDto.Id);
            _mapper.Map(request.UpdateMatchDto, match);
            await _matchRepository.Update(match);
        }
    }
}
