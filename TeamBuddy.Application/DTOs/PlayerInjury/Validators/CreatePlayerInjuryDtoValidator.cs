using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.PlayerInjury.Validators
{
    public class CreatePlayerInjuryDtoValidator : AbstractValidator<CreatePlayerInjuryDto>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IBaseDataRepository _baseDataRepository;

        public CreatePlayerInjuryDtoValidator(ITeamMemberRepository teamMemberRepository, IBaseDataRepository baseDataRepository)
        {
            _teamMemberRepository = teamMemberRepository;
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.PlayerId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _teamMemberRepository.IsExist(id);
                });

            Include(new PlayerInjuryDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
