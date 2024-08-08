using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Club;
using TeamBuddy.Application.Features.Club.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Club.Handlers.Commands
{
    public class UpdateClubRequestHandler : IRequestHandler<UpdateClubRequest>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public UpdateClubRequestHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateClubRequest request, CancellationToken cancellationToken)
        {
            var club = await _clubRepository.Get(request.UpdateClubDto.Id);
            _mapper.Map(request.UpdateClubDto, club);
            await _clubRepository.Update(club);
        }
    }
}
