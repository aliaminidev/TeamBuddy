using MediatR;

namespace TeamBuddy.Application.Features.TrainingSession.Requests.Commands
{
    public class DeleteTrainingSessionRequest : IRequest
    {
        public int Id { get; set; }
    }
}
