using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.Team.Validators
{
    public class CreateTeamDtoValidator : AbstractValidator<CreateTeamDto>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IBaseDataRepository _baseDataRepository;

        public CreateTeamDtoValidator(IClubRepository clubRepository, IBaseDataRepository baseDataRepository)
        {
            _clubRepository = clubRepository;
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.ClubId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _clubRepository.IsExist(id);
                });

            RuleFor(x => x.SportId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _baseDataRepository.IsExist(id);
                });

            Include(new TeamDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
