using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.PlayerInjury;
using TeamBuddy.Application.Features.PlayerInjury.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerInjury.Handlers.Queries
{
    public class GetPlayerInjuryListRequestHandler : IRequestHandler<GetPlayerInjuryListRequest, List<PlayerInjuryDto>>
    {
        private readonly IPlayerInjuryRepository _playerInjuryRepository;
        private readonly IMapper _mapper;

        public GetPlayerInjuryListRequestHandler(IPlayerInjuryRepository playerInjuryRepository, IMapper mapper)
        {
            _playerInjuryRepository = playerInjuryRepository;
            _mapper = mapper;
        }

        public async Task<List<PlayerInjuryDto>> Handle(GetPlayerInjuryListRequest request, CancellationToken cancellationToken)
        {
            var playerInjuryList = await _playerInjuryRepository.GetAll();
            return _mapper.Map<List<PlayerInjuryDto>>(playerInjuryList);
        }
    }
}
