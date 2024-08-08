using MediatR;
using TeamBuddy.Application.DTOs.BaseData;

namespace TeamBuddy.Application.Features.BaseData.Requests.Queries
{
    public class GetBaseDataRequest : IRequest<BaseDataDto>
    {
        public long Id { get; set; }
    }
}
