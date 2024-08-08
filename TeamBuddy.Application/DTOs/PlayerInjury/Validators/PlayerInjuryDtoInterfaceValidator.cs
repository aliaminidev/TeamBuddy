using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.PlayerInjury.Validators
{
    public class PlayerInjuryDtoInterfaceValidator : AbstractValidator<IPlayerInjuryDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public PlayerInjuryDtoInterfaceValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.InjuryTypeId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _baseDataRepository.IsExist(id);
                });

            RuleFor(x => x.DateTime).
                NotNull().
                LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.EstimatedRecoveryDuration).
                NotNull().
                GreaterThanOrEqualTo(0);

            RuleFor(x => x.Description).
                MaximumLength(5000);
        }
    }
}
