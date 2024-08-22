using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Club.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.Club.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Club.Handlers.Commands
{
    public class CreateClubRequestHandler : IRequestHandler<CreateClubRequest, int>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDataRepository _baseDataRepository;

        public CreateClubRequestHandler(IClubRepository clubRepository, IMapper mapper, IBaseDataRepository baseDataRepository)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
            _baseDataRepository = baseDataRepository;
        }

        public async Task<int> Handle(CreateClubRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateClubDtoValidator(_baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.CreateClubDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var club = _mapper.Map<Domain.Club>(request.CreateClubDto);
            club = await _clubRepository.Add(club);
            return club.Id;
        }
    }
}
