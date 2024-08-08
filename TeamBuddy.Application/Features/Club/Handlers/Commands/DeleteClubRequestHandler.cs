using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.Club.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Club.Handlers.Commands
{
    public class DeleteClubRequestHandler : IRequestHandler<DeleteClubRequest>
    {
        private readonly IClubRepository _clubRepository;

        public DeleteClubRequestHandler(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public async Task Handle(DeleteClubRequest request, CancellationToken cancellationToken)
        {
            var club = await _clubRepository.Get(request.Id);
            await _clubRepository.Delete(club);
        }
    }
}
