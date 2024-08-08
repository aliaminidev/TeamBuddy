using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.TrainingSession.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingSession.Handlers.Commands
{
    public class CreateTrainingSessionRequestHandler : IRequestHandler<CreateTrainingSessionRequest, int>
    {
        private readonly ITrainingSessionRepository _trainingSessionRepository;
        private readonly IMapper _mapper;

        public CreateTrainingSessionRequestHandler(ITrainingSessionRepository trainingSessionRepository, IMapper mapper)
        {
            _trainingSessionRepository = trainingSessionRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTrainingSessionRequest request, CancellationToken cancellationToken)
        {
            var trainingSession = _mapper.Map<Domain.TrainingSession>(request.CreateTrainingSessionDto);
            trainingSession = await _trainingSessionRepository.Add(trainingSession);
            return trainingSession.Id;
        }
    }
}
