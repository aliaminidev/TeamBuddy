using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Club;
using TeamBuddy.Application.DTOs.Club.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.Club.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Club.Handlers.Commands
{
    public class UpdateClubRequestHandler : IRequestHandler<UpdateClubRequest>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdateClubRequestHandler(IClubRepository clubRepository, IMapper mapper, IBaseDataRepository baseDataRepository)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
            _baseDataRepository = baseDataRepository;
        }

        public async Task Handle(UpdateClubRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateClubDtoValidator(_baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateClubDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var club = await _clubRepository.Get(request.UpdateClubDto.Id)
                ?? throw new NotFoundException(nameof(Domain.Club), request.UpdateClubDto.Id);

            _mapper.Map(request.UpdateClubDto, club);
            await _clubRepository.Update(club);
        }
    }
}
