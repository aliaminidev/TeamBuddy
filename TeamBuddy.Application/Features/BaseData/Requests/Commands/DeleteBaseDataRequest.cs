using MediatR;

namespace TeamBuddy.Application.Features.BaseData.Requests.Commands
{
    public class DeleteBaseDataRequest : IRequest
    {
        public long Id { get; set; }
    }
}
