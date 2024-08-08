using MediatR;
using TeamBuddy.Application.DTOs.TrainingSession;

namespace TeamBuddy.Application.Features.TrainingSession.Requests.Queries
{
    public class GetTrainingSessionRequest : IRequest<TrainingSessionDto>
    {
        public int Id { get; set; }
    }
}
