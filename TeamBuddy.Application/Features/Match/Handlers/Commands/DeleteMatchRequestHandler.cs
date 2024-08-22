using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.Match.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Match.Handlers.Commands
{
    public class DeleteMatchRequestHandler : IRequestHandler<DeleteMatchRequest>
    {
        private readonly IMatchRepository _matchRepository;

        public DeleteMatchRequestHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task Handle(DeleteMatchRequest request, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.Get(request.Id)
                ?? throw new NotFoundException(nameof(Domain.Match), request.Id);

            await _matchRepository.Delete(match);
        }
    }
}
