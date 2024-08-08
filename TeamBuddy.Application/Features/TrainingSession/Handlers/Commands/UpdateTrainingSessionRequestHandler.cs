using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.TrainingSession;
using TeamBuddy.Application.Features.TrainingSession.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingSession.Handlers.Commands
{
    public class UpdateTrainingSessionRequestHandler : IRequestHandler<UpdateTrainingSessionRequest>
    {
        private readonly ITrainingSessionRepository _trainingSessionRepository;
        private readonly IMapper _mapper;

        public UpdateTrainingSessionRequestHandler(ITrainingSessionRepository trainingSessionRepository, IMapper mapper)
        {
            _trainingSessionRepository = trainingSessionRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTrainingSessionRequest request, CancellationToken cancellationToken)
        {
            var trainingSession = await _trainingSessionRepository.Get(request.UpdateTrainingSessionDto.Id);
            _mapper.Map(request.UpdateTrainingSessionDto, trainingSession);
            await _trainingSessionRepository.Update(trainingSession);
        }
    }
}
