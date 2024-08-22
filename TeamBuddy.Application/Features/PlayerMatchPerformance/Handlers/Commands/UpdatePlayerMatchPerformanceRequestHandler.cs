using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.PlayerInjury.Validators;
using TeamBuddy.Application.DTOs.PlayerMatchPerformance;
using TeamBuddy.Application.DTOs.PlayerMatchPerformance.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.PlayerMatchPerformance.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerMatchPerformance.Handlers.Commands
{
    public class UpdatePlayerMatchPerformanceRequestHandler : IRequestHandler<UpdatePlayerMatchPerformanceRequest>
    {
        private readonly IPlayerMatchPerformanceRepository _playerMatchPerformanceRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdatePlayerMatchPerformanceRequestHandler
            (IPlayerMatchPerformanceRepository playerMatchPerformanceRepository, IMapper mapper, IBaseDataRepository baseDataRepository)
        {
            _playerMatchPerformanceRepository = playerMatchPerformanceRepository;
            _mapper = mapper;
            _baseDataRepository = baseDataRepository;
        }

        public async Task Handle(UpdatePlayerMatchPerformanceRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePlayerMatchPerformanceDtoValidator(_baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.UpdatePlayerMatchPerformanceDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var playerMatchPerformance = await _playerMatchPerformanceRepository.Get(request.UpdatePlayerMatchPerformanceDto.Id)
                ?? throw new NotFoundException(nameof(Domain.PlayerMatchPerformance), request.UpdatePlayerMatchPerformanceDto.Id);

            _mapper.Map(request.UpdatePlayerMatchPerformanceDto, playerMatchPerformance);
            await _playerMatchPerformanceRepository.Update(playerMatchPerformance);
        }
    }
}
