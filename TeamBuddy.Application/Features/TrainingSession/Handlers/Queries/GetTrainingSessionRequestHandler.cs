using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.TrainingSession;
using TeamBuddy.Application.Features.TrainingSession.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingSession.Handlers.Queries
{
    public class GetTrainingSessionRequestHandler : IRequestHandler<GetTrainingSessionRequest, TrainingSessionDto>
    {
        private readonly ITrainingSessionRepository _trainingSessionRepository;
        private readonly IMapper _mapper;

        public GetTrainingSessionRequestHandler(ITrainingSessionRepository trainingSessionRepository, IMapper mapper)
        {
            _trainingSessionRepository = trainingSessionRepository;
            _mapper = mapper;
        }

        public async Task<TrainingSessionDto> Handle(GetTrainingSessionRequest request, CancellationToken cancellationToken)
        {
            var trainingSession = await _trainingSessionRepository.Get(request.Id);
            return _mapper.Map<TrainingSessionDto>(trainingSession);
        }
    }
}
