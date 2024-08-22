using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.DTOs.BaseData.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.BaseData.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.BaseData.Handlers.Commands
{
    public class UpdateBaseDataRequestHandler : IRequestHandler<UpdateBaseDataRequest>
    {
        private readonly IBaseDataRepository _baseDataRepository;
        private readonly IMapper _mapper;

        public UpdateBaseDataRequestHandler(IBaseDataRepository baseDataRepository, IMapper mapper)
        {
            _baseDataRepository = baseDataRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBaseDataRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBaseDataDtoValidator(_baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateBaseDataDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var baseData = await _baseDataRepository.Get(request.UpdateBaseDataDto.Id)
                ?? throw new NotFoundException(nameof(Domain.BaseData), request.UpdateBaseDataDto.Id);

            _mapper.Map(request.UpdateBaseDataDto, baseData);
            await _baseDataRepository.Update(baseData);
        }
    }
}
