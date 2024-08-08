using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.BaseData.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.BaseData.Handlers.Commands
{
    public class DeleteBaseDataRequestHandler : IRequestHandler<DeleteBaseDataRequest>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public DeleteBaseDataRequestHandler(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;
        }

        public async Task Handle(DeleteBaseDataRequest request, CancellationToken cancellationToken)
        {
            var baseData = await _baseDataRepository.Get(request.Id);
            await _baseDataRepository.Delete(baseData);
        }
    }
}
