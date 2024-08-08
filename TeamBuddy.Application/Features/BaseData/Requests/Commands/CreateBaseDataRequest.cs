using MediatR;
using TeamBuddy.Application.DTOs.BaseData;

namespace TeamBuddy.Application.Features.BaseData.Requests.Commands
{
    public class CreateBaseDataRequest : IRequest<long>
    {
        public CreateBaseDataDto CreateBaseDataDto { get; set; }
    }
}
