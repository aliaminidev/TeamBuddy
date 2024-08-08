using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.Team.Validators
{
    public class UpdateTeamDtoValidator : AbstractValidator<UpdateTeamDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdateTeamDtoValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.Id).
                NotNull().
                GreaterThan(0);

            Include(new TeamDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
