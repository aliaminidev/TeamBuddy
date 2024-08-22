using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using TeamBuddy.Application.DTOs.BaseData.Validators;
using TeamBuddy.Application.Exceptions;
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
            var validator = new CreateBaseDataDtoValidator(_baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.CreateBaseDataDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var baseData = _mapper.Map<Domain.BaseData>(request.CreateBaseDataDto);
            baseData = await _baseDataRepository.Add(baseData);
            return baseData.Id;
        }
    }
}
