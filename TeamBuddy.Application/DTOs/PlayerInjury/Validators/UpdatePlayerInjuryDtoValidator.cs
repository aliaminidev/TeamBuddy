using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.PlayerInjury.Validators
{
    public class UpdatePlayerInjuryDtoValidator : AbstractValidator<UpdatePlayerInjuryDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdatePlayerInjuryDtoValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.Id).
                NotNull().
                GreaterThan(0);

            Include(new PlayerInjuryDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
