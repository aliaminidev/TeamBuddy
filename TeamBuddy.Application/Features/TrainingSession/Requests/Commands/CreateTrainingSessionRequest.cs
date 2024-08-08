using MediatR;
using TeamBuddy.Application.DTOs.TrainingSession;

namespace TeamBuddy.Application.Features.TrainingSession.Requests.Commands
{
    public class CreateTrainingSessionRequest : IRequest<int>
    {
        public CreateTrainingSessionDto CreateTrainingSessionDto { get; set; }
    }
}
