using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Club;
using TeamBuddy.Application.Features.Club.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Club.Handlers.Queries
{
    public class GetClubListRequestHandler : IRequestHandler<GetClubListRequest, List<ClubDto>>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public GetClubListRequestHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<List<ClubDto>> Handle(GetClubListRequest request, CancellationToken cancellationToken)
        {
            var clubList = await _clubRepository.GetAll();
            return _mapper.Map<List<ClubDto>>(clubList);
        }
    }
}
