using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Club;
using TeamBuddy.Application.Features.Club.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Club.Handlers.Queries
{
    public class GetClubRequestHandler : IRequestHandler<GetClubRequest, ClubDto>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public GetClubRequestHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<ClubDto> Handle(GetClubRequest request, CancellationToken cancellationToken)
        {
            var club = await _clubRepository.Get(request.Id);
            return _mapper.Map<ClubDto>(club);
        }
    }
}
