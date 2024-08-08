using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.TrainingSession;
using TeamBuddy.Application.Features.TrainingSession.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingSession.Handlers.Queries
{
    public class GetTrainingSessionListRequestHandler : IRequestHandler<GetTrainingSessionListRequest, List<TrainingSessionDto>>
    {
        private readonly ITrainingSessionRepository _trainingSessionRepository;
        private readonly IMapper _mapper;

        public GetTrainingSessionListRequestHandler(ITrainingSessionRepository trainingSessionRepository, IMapper mapper)
        {
            _trainingSessionRepository = trainingSessionRepository;
            _mapper = mapper;
        }

        public async Task<List<TrainingSessionDto>> Handle(GetTrainingSessionListRequest request, CancellationToken cancellationToken)
        {
            var trainingSessionList = await _trainingSessionRepository.GetAll();
            return _mapper.Map<List<TrainingSessionDto>>(trainingSessionList);
        }
    }
}
