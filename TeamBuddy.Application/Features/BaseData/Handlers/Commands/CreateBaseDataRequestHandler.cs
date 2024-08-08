using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.BaseData.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.BaseData.Handlers.Commands
{
    public class CreateBaseDataRequestHandler : IRequestHandler<CreateBaseDataRequest, long>
    {
        private readonly IBaseDataRepository _baseDataRepository;
        private readonly IMapper _mapper;

        public CreateBaseDataRequestHandler(IBaseDataRepository baseDataRepository, IMapper mapper)
        {
            _baseDataRepository = baseDataRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateBaseDataRequest request, CancellationToken cancellationToken)
        {
            var baseData = _mapper.Map<Domain.BaseData>(request.CreateBaseDataDto);
            baseData = await _baseDataRepository.Add(baseData);
            return baseData.Id;
        }
    }
}
