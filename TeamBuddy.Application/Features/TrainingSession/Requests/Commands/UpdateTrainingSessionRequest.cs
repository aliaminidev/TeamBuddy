using MediatR;
using TeamBuddy.Application.DTOs.TrainingSession;

namespace TeamBuddy.Application.Features.TrainingSession.Requests.Commands
{
    public class UpdateTrainingSessionRequest : IRequest
    {
        public UpdateTrainingSessionDto UpdateTrainingSessionDto { get; set; }
    }
}
