using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.Club.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Club.Handlers.Commands
{
    public class CreateClubRequestHandler : IRequestHandler<CreateClubRequest, int>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public CreateClubRequestHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClubRequest request, CancellationToken cancellationToken)
        {
            var club = _mapper.Map<Domain.Club>(request.CreateClubDto);
            club = await _clubRepository.Add(club);
            return club.Id;
        }
    }
}
