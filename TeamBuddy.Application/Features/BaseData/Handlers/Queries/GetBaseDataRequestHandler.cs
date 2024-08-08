using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.Features.BaseData.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.BaseData.Handlers.Queries
{
    public class GetBaseDataRequestHandler : IRequestHandler<GetBaseDataRequest, BaseDataDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;
        private readonly IMapper _mapper;

        public GetBaseDataRequestHandler(IBaseDataRepository baseDataRepository, IMapper mapper)
        {
            _baseDataRepository = baseDataRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataDto> Handle(GetBaseDataRequest request, CancellationToken cancellationToken)
        {
            var baseData = await _baseDataRepository.Get(request.Id);
            return _mapper.Map<BaseDataDto>(baseData);
        }
    }
}
