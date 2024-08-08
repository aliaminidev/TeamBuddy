using MediatR;
using TeamBuddy.Application.DTOs.BaseData;

namespace TeamBuddy.Application.Features.BaseData.Requests.Commands
{
    public class UpdateBaseDataRequest : IRequest
    {
        public UpdateBaseDataDto UpdateBaseDataDto { get; set; }
    }
}
