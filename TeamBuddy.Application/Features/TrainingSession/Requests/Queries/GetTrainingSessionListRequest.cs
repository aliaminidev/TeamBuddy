using System.Collections.Generic;
using MediatR;
using TeamBuddy.Application.DTOs.TrainingSession;

namespace TeamBuddy.Application.Features.TrainingSession.Requests.Queries
{
    public class GetTrainingSessionListRequest : IRequest<List<TrainingSessionDto>>
    {
    }
}
