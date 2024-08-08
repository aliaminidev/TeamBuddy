using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.Features.BaseData.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.BaseData.Handlers.Queries
{
    public class GetBaseDataListRequestHandler : IRequestHandler<GetBaseDataListRequest, List<BaseDataDto>>
    {
        private readonly IBaseDataRepository _baseDataRepository;
        private readonly IMapper _mapper;

        public GetBaseDataListRequestHandler(IBaseDataRepository baseDataRepository, IMapper mapper)
        {
            _baseDataRepository = baseDataRepository;
            _mapper = mapper;
        }

        public async Task<List<BaseDataDto>> Handle(GetBaseDataListRequest request, CancellationToken cancellationToken)
        {
            var baseDataList = await _baseDataRepository.GetAll();
            return _mapper.Map<List<BaseDataDto>>(baseDataList);
        }
    }
}
