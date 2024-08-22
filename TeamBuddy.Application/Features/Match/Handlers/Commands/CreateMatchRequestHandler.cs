using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Club.Validators;
using TeamBuddy.Application.DTOs.Match.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.Match.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Match.Handlers.Commands
{
    public class CreateMatchRequestHandler : IRequestHandler<CreateMatchRequest, int>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        private readonly IBaseDataRepository _baseDataRepository;

        public CreateMatchRequestHandler(IMatchRepository matchRepository, IMapper mapper,
            ITeamRepository teamRepository, IBaseDataRepository baseDataRepository)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
            _teamRepository = teamRepository;
            _baseDataRepository = baseDataRepository;
        }

        public async Task<int> Handle(CreateMatchRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateMatchDtoValidator(_teamRepository, _baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.CreateMatchDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var match = _mapper.Map<Domain.Match>(request.CreateMatchDto);
            match = await _matchRepository.Add(match);
            return match.Id;
        }
    }
}
