using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.TrainingSession.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingSession.Handlers.Commands
{
    public class DeleteTrainingSessionRequestHandler : IRequestHandler<DeleteTrainingSessionRequest>
    {
        private readonly ITrainingSessionRepository _trainingSessionRepository;

        public DeleteTrainingSessionRequestHandler(ITrainingSessionRepository trainingSessionRepository)
        {
            _trainingSessionRepository = trainingSessionRepository;
        }

        public async Task Handle(DeleteTrainingSessionRequest request, CancellationToken cancellationToken)
        {
            var trainingSession = await _trainingSessionRepository.Get(request.Id)
                ?? throw new NotFoundException(nameof(Domain.TrainingSession), request.Id);

            await _trainingSessionRepository.Delete(trainingSession);
        }
    }
}
