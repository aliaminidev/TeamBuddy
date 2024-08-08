using System.Collections.Generic;
using MediatR;
using TeamBuddy.Application.DTOs.BaseData;

namespace TeamBuddy.Application.Features.BaseData.Requests.Queries
{
    public class GetBaseDataListRequest : IRequest<List<BaseDataDto>>
    {

    }
}
