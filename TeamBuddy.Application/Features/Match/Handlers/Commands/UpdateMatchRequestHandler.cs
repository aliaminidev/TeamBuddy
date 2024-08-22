using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.BaseData.Validators;
using TeamBuddy.Application.DTOs.Match;
using TeamBuddy.Application.DTOs.Match.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.Match.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Match.Handlers.Commands
{
    public class UpdateMatchRequestHandler : IRequestHandler<UpdateMatchRequest>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdateMatchRequestHandler(IMatchRepository matchRepository, IMapper mapper, IBaseDataRepository baseDataRepository)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
            _baseDataRepository = baseDataRepository;
        }

        public async Task Handle(UpdateMatchRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMatchDtoValidator(_baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateMatchDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var match = await _matchRepository.Get(request.UpdateMatchDto.Id)
                ?? throw new NotFoundException(nameof(Domain.Match), request.UpdateMatchDto.Id);

            _mapper.Map(request.UpdateMatchDto, match);
            await _matchRepository.Update(match);
        }
    }
}
